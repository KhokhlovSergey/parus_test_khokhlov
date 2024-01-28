using Microsoft.EntityFrameworkCore;

namespace parus_test_khokhlov.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
