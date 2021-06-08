using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        private const string LocalConnectionString =
            "Host=localhost;Database=dotnet_exam;Username=postgres;Password=qweasd123";
        
        public DbSet<LoanApplication> LoanApplication { get; set; }

        public ApplicationContext() { }
        
        public ApplicationContext(DbContextOptions options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(LocalConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");
        }
    }
}