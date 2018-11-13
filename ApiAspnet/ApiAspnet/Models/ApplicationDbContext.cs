using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ApiAspnet.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
           : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<TodoItem> TodoItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}