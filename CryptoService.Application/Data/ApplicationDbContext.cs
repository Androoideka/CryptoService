using CryptoService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoService.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<PriceData> Prices { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ILoader loader = new EFTestLoader();
            modelBuilder.Entity<Symbol>().HasData(loader.GetData());
        }*/
    }
}
