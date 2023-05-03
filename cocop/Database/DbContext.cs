using cocop.Models;
using Microsoft.EntityFrameworkCore;//Import EF
namespace cocop.Database
{
    public class DataDbContext:DbContext
    {
        //Constructure Method
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        // Tabke Manufacturers
        public DbSet<manufacturers>manufacturers { get; set; }
        
        // Tabke Manufacturers
        public DbSet<devices> devices { get; set; }
    }

}
