namespace VendorTrack.Models.DTOs
{
    public class AddNewVendorNcrDTO
    {
        public required string PartNumber { get; set; }
        public int Fault { get; set; }
        public DateOnly ReceivedDate { get; set; }
        public int ReceivedQuantity { get; set; }
        public int NonConformingQuantity { get; set; }
        public required string VendorName { get; set; }
        public required string ContactName { get; set; }
        public required string ContactEmail { get; set; }
    }
}
