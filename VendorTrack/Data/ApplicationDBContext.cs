using Microsoft.EntityFrameworkCore;
using VendorTrack.Models.Entities;
using VendorTrack.Models.DTOs;

namespace VendorTrack.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<VendorNcr> VendorNcrs { get; set; }
        public DbSet<NcrFault> NcrFaults { get; set; }
        public DbSet<Counter> Counters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NcrFault>().HasData(
                new NcrFault
                {
                    FaultId = 1,
                    FaultDescription = "Damage",
                    ActiveStatus = true
                },
                new NcrFault
                {
                    FaultId = 2,
                    FaultDescription = "Dimension",
                    ActiveStatus = true
                },
                new NcrFault
                {
                    FaultId = 3,
                    FaultDescription = "Scratch",
                    ActiveStatus = true
                },
                new NcrFault
                {
                    FaultId = 4,
                    FaultDescription = "Others",
                    ActiveStatus = true
                }
            );
        }
    }
}
