using VendorTrack.Data;
using VendorTrack.Helper;
using VendorTrack.Models.DTOs;
using VendorTrack.Models.Entities;

namespace VendorTrack.Repositories
{
    public class VendorNcrRepository : IVendorNcrRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly INcrNumberGenerator _ncrNumberGenerator;

        public VendorNcrRepository(ApplicationDBContext context, INcrNumberGenerator ncrNumberGenerator)
        {
            _context = context;
            _ncrNumberGenerator = ncrNumberGenerator;
        }

        public List<NcrFaultDTO> GetNcrFaults()
        {
            var NcrFaultDTOlist = _context.NcrFaults
                .Select(x => new NcrFaultDTO
                {
                    FaultId = x.FaultId,
                    FaultDescription = x.FaultDescription
                }).ToList();

            return NcrFaultDTOlist;
        }
        public List<VendorNcrDTO> GetVendorNcrs()
        {
            var VendorNcrDTOlist = _context.VendorNcrs
                 .GroupJoin(
                 _context.NcrFaults,
                 a => a.Fault,
                 b => b.FaultId,
                 (a, b) => new { a, b }
                 )
                 .SelectMany(
                     x => x.b.DefaultIfEmpty(),
                     (x, b) => new VendorNcrDTO
                     {
                         VendorNcrId = x.a.VendorNcrId,
                         NcrNumber = x.a.NcrNumber,
                         PartNumber = x.a.PartNumber,
                         FaultDescription = b != null ? b.FaultDescription : "N/A",
                         ReceivedDate = x.a.ReceivedDate,
                         ReceivedQuantity = x.a.ReceivedQuantity,
                         NonConformingQuantity = x.a.NonConformingQuantity,
                         VendorName = x.a.VendorName,
                         ContactName = x.a.ContactName,
                         ContactEmail = x.a.ContactEmail
                     }
                 ).ToList();

            return VendorNcrDTOlist;
        }

        public List<VendorNcrDTO> GetVendorNcrById(int ncrId)
        {
            var VendorNcrDTOlist = _context.VendorNcrs
                .Where(o => o.VendorNcrId == ncrId)
                .Select(s => new VendorNcrDTO
                {
                    VendorNcrId = s.VendorNcrId,
                    NcrNumber = s.NcrNumber,
                    PartNumber = s.PartNumber,
                    Fault = s.Fault,
                    ReceivedDate = s.ReceivedDate,
                    ReceivedQuantity = s.ReceivedQuantity,
                    NonConformingQuantity = s.NonConformingQuantity,
                    VendorName = s.VendorName,
                    ContactName = s.ContactName,
                    ContactEmail = s.ContactEmail
                }).ToList();
            return VendorNcrDTOlist;
        }

        public void SaveNewVendorNCR(AddNewVendorNcrDTO addNewVendorNcrDTO)
        {
            var VendorNcrEntity = new VendorNcr()
            {
                NcrNumber = _ncrNumberGenerator.GenerateNcrNumber(),
                PartNumber = addNewVendorNcrDTO.PartNumber,
                Fault = addNewVendorNcrDTO.Fault,
                ReceivedDate = addNewVendorNcrDTO.ReceivedDate,
                ReceivedQuantity = addNewVendorNcrDTO.ReceivedQuantity,
                NonConformingQuantity = addNewVendorNcrDTO.NonConformingQuantity,
                VendorName = addNewVendorNcrDTO.VendorName,
                ContactName = addNewVendorNcrDTO.ContactName,
                ContactEmail = addNewVendorNcrDTO.ContactEmail,
            };
            _context.Add(VendorNcrEntity);
            _context.SaveChanges();
        }
        public void UpdateVendorNCR(UpdateVendorNcrDTO updateVendorNcrDTO)
        {
            var VendorNcrEntity = _context.VendorNcrs.Find(updateVendorNcrDTO.VendorNcrId);

            if (VendorNcrEntity == null) return;

            VendorNcrEntity.NcrNumber = updateVendorNcrDTO.NcrNumber;
            VendorNcrEntity.PartNumber = updateVendorNcrDTO.PartNumber;
            VendorNcrEntity.Fault = updateVendorNcrDTO.Fault;
            VendorNcrEntity.ReceivedDate = updateVendorNcrDTO.ReceivedDate;
            VendorNcrEntity.ReceivedQuantity = updateVendorNcrDTO.ReceivedQuantity;
            VendorNcrEntity.NonConformingQuantity = updateVendorNcrDTO.NonConformingQuantity;
            VendorNcrEntity.VendorName = updateVendorNcrDTO.VendorName;
            VendorNcrEntity.ContactName = updateVendorNcrDTO.ContactName;
            VendorNcrEntity.ContactEmail = updateVendorNcrDTO.ContactEmail;

            _context.SaveChanges();
        }

        public void DeleteVendorNCR(int ncrId)
        {
            var VendorNcr = _context.VendorNcrs.Find(ncrId);
            if (VendorNcr == null) return;
            _context.VendorNcrs.Remove(VendorNcr);
            _context.SaveChanges();
        }
    }
        
}
