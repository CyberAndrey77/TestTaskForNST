using Microsoft.EntityFrameworkCore;

namespace TestTaskForNST.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
