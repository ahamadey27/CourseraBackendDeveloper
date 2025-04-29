using Microsoft.EntityFrameworkCore;

namespace CRUDWithMySQL.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=sys;User=root;Password=alex;", new MySqlServerVersion(new Version(8, 0, 26)));
        }
        // Configuration and DbSet properties will be added here
    }
}
