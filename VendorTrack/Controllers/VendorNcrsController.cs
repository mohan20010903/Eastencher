using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorTrack.Data;
using VendorTrack.Helper;
using VendorTrack.Models.DTOs;
using VendorTrack.Models.Entities;

namespace VendorTrack.Controllers
{
    public class VendorNcrsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly INcrNumberGenerator _ncrNumberGenerator;

        public VendorNcrsController(ApplicationDBContext context, INcrNumberGenerator ncrNumberGenerator)
        {
            _context = context;
            _ncrNumberGenerator = ncrNumberGenerator;
        }

        public IActionResult Index()
        {
            var VendorFaultDTOlist = _context.NcrFaults
                .Select(x => new NcrFaultDTO
                {
                    FaultId = x.FaultId,
                    FaultDescription = x.FaultDescription
                }).ToList();
            return View("ManageNCR", VendorFaultDTOlist);
        }
        public IActionResult ViewVendorNCRs()
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

            return View(VendorNcrDTOlist);
        }

        [HttpPost]
        public IActionResult GetVendorNcrById([FromBody] int ncrId)
        {
            var VendorNcrDTOlist = _context.VendorNcrs
                .Where(o => o.VendorNcrId == ncrId)
                .Select(s => new VendorNcrDTO {
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
                });

            if (VendorNcrDTOlist == null) return BadRequest(new { message = "NCR not found" });

            return Ok(VendorNcrDTOlist);
        }

        [HttpPost]
        public IActionResult SaveNewVendorNCR([FromBody] AddNewVendorNcrDTO addNewVendorNcrDTO)
        {
            if (ModelState.IsValid)
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
                return Ok(new { message = "NCR created successfully" });
            }
            return BadRequest(new { message = "Something went wrong" });
        }

        [HttpPut]
        public IActionResult UpdateVendorNCR([FromBody] UpdateVendorNcrDTO updateVendorNcrDTO)
        {
            if (ModelState.IsValid)
            {
                var VendorNcrEntity = _context.VendorNcrs.Find(updateVendorNcrDTO.VendorNcrId);

                if(VendorNcrEntity == null) return BadRequest(new { message = "NCR not found" });

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
                return Ok(new { message = "NCR updated successfully" });
            }
            return BadRequest(new { message = "Something went wrong" });
        }

        [HttpDelete]
        public IActionResult DeleteNcr([FromBody] int ncrId)
        {
            var VendorNcr = _context.VendorNcrs.Find(ncrId);
            if (VendorNcr == null) return BadRequest(new { message = "NCR not found" });
            _context.VendorNcrs.Remove(VendorNcr);
            _context.SaveChanges();
            return Ok(new { message = "NCR deleted successfully" });
        }
    }
}
