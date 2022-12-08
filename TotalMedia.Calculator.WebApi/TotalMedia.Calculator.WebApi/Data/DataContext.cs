using Microsoft.EntityFrameworkCore;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<VatRate> VatRates => Set<VatRate>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
