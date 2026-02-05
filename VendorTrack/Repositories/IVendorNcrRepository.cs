using VendorTrack.Models.DTOs;

namespace VendorTrack.Repositories
{
    public interface IVendorNcrRepository
    {
        List<NcrFaultDTO> GetNcrFaults();
        List<VendorNcrDTO> GetVendorNcrs();
        List<VendorNcrDTO> GetVendorNcrById(int ncrId);
        void SaveNewVendorNCR(AddNewVendorNcrDTO addNewVendorNcrDTO);
        void UpdateVendorNCR(UpdateVendorNcrDTO updateVendorNcrDTO); 
        void DeleteVendorNCR(int ncrId);
    }
}
