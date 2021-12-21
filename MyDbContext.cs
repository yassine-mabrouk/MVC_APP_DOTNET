using Microsoft.EntityFrameworkCore;
using webProject.Model;
namespace webProject
{
    public class MyDbContext:DbContext{
        public DbSet<Student> students{get;set;}
        public MyDbContext(DbContextOptions options):base(options){

        }
    }
}