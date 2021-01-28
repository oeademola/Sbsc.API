using System.Collections.Generic;
using System.Threading.Tasks;
using Sbsc.API.Models;

namespace Sbsc.API.Interfaces
{
    public interface IGeneralRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Student>> GetStudentsAsync();
         Task<Student> GetStudentByIdAsync(int id);
    }
}