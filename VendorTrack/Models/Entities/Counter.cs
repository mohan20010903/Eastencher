using System.ComponentModel.DataAnnotations;

namespace VendorTrack.Models.Entities
{
    public class Counter
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public required string Reference { get; set; }
        public int LastGeneratedNumber { get; set; }
    }
}
