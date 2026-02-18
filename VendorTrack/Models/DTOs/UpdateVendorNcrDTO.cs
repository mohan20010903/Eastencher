using System.ComponentModel.DataAnnotations;

namespace VendorTrack.Models.DTOs
{
    public class UpdateVendorNcrDTO
    {
        public int VendorNcrId { get; set; }

        [MaxLength(10)]
        public required string NcrNumber { get; set; }

        [MaxLength(50)]
        public required string PartNumber { get; set; }
        public int Fault { get; set; }
        public DateOnly ReceivedDate { get; set; }
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
