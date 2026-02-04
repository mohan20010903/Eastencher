using System.ComponentModel.DataAnnotations;

namespace VendorTrack.Models.DTOs
{
    public class NcrFaultDTO
    {
        public int FaultId { get; set; }

        [MaxLength(50)]
        public required string FaultDescription { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
