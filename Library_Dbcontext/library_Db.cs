using library_Domin;
using Microsoft.EntityFrameworkCore;

namespace Library_Dbcontext
{
    public class library_Db:DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<User>? Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB ; Initial Catalog = labrary_Data");
        }

    }
}