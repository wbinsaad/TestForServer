using Microsoft.EntityFrameworkCore;
using TestForServer.Models;

namespace TestForServer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Text> Texts { get; set; }
    }
}
