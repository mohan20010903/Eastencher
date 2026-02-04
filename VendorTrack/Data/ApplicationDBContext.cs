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
        public DbSet<Counters> Counters { get; set; }
    }
}
