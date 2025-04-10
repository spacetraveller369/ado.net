using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal static partial class Program
    {
        public class AppDbContext : DbContext
        {
            public DbSet<User>? Users { get; set; } 

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EFCoreDB;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}