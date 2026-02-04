using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorTrack.Models.DTOs
{
    public class VendorNcrDTO
    {
        [Key]
        public int VendorNcrId { get; set; }

        [MaxLength(10)]
        public required string NcrNumber { get; set; }

        [MaxLength(50)]
        public required string PartNumber { get; set; }

        [MaxLength(100)]
        public required string Fault { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ReceivedDate { get; set; }
        public int ReceivedQuantity { get; set; }
        public int NonConformingQuantity { get; set; }

        [MaxLength(50)]
        public required string VendorName { get; set; }

        [MaxLength(20)]
        public required string ContactName { get; set; }

        [MaxLength(100)]
        public required string ContactEmail { get; set; }
    }
}
