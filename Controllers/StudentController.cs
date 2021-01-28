using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sbsc.API.Dtos;
using Sbsc.API.Interfaces;
using Sbsc.API.Models;

namespace Sbsc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGeneralRepository _repo;
        private readonly IMapper _mapper;
        public StudentController(IGeneralRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repo.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _repo.GetStudentByIdAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            // if (student.CountryOfOrigin == null)
            //     return NotFound();
            _repo.Add(student);

            if (await _repo.SaveAll())
            {
                var studentToReturn = _mapper.Map<StudentDto>(student);

                return new CreatedAtRouteResult("GetStudent", new { id = student.Id }, studentToReturn);
            }

            return StatusCode(500, new { status = "error", message = "Error Occured please try again later, please try again later..." });


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentDto studentDto)
        {
            var studentFromDb = await _repo.GetStudentByIdAsync(id);

            if (studentFromDb == null)
                return NotFound(new { status = "error", message = "student not found" });

            studentFromDb = _mapper.Map(studentDto, studentFromDb);

            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return StatusCode(500, new { status = "error", message = "Error Occured please try again later, please try again later..." });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var studentFromDb = await _repo.GetStudentByIdAsync(id);
            _repo.Delete(studentFromDb);
            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return StatusCode(500, new { status = "error", message = "Error Occured please try again later, please try again later..." });


        }



    }
}