using Microsoft.EntityFrameworkCore;
using Sbsc.API.Models;

namespace Sbsc.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}