using Microsoft.EntityFrameworkCore;
using WasteControl.Core.Entities;

namespace WasteControl.Infrastructure.DAL
{
    public class WasteControlDbContext : DbContext
    {
        public DbSet<ReceivingCompany> ReceivingCompanies { get; set; }
        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Waste> Wastes { get; set; }
        public DbSet<WasteExport> WasteExports { get; set; }

        public WasteControlDbContext(DbContextOptions<WasteControlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        
    }
}