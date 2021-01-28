using AutoMapper;
using Sbsc.API.Dtos;
using Sbsc.API.Models;

namespace Sbsc.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<StudentDto, Student>().ReverseMap();
        }
        
    }
}