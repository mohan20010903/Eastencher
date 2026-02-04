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
        public DbSet<VendorNcr> VendorNcr { get; set; }
        public DbSet<VendorTrack.Models.DTOs.VendorNcrDTO> VendorNcrDTO { get; set; } = default!;
    }
}
