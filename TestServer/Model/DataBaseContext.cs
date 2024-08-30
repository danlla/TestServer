using Microsoft.EntityFrameworkCore;

namespace TestServer.Model
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
