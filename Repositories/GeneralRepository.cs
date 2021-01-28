using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sbsc.API.Data;
using Sbsc.API.Interfaces;
using Sbsc.API.Models;

namespace Sbsc.API.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly DataContext _context;
        public GeneralRepository(DataContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}