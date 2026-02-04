using System.ComponentModel.DataAnnotations;

namespace VendorTrack.Models.Entities
{
    public class NcrFault
    {
        [Key]
        public int FaultId { get; set; }

        [MaxLength(50)]
        public required string FaultDescription { get; set; }
        public bool ActiveStatus { get; set; }

    }
}
