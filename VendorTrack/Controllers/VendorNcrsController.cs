using Microsoft.AspNetCore.Mvc;
using VendorTrack.Models.DTOs;
using VendorTrack.Repositories;

namespace VendorTrack.Controllers
{
    public class VendorNcrsController : Controller
    {
        private readonly IVendorNcrRepository _vendorNcrRepository;

        public VendorNcrsController(IVendorNcrRepository vendorNcrRepository)
        {
            _vendorNcrRepository = vendorNcrRepository;
        }

        public IActionResult Index()
        {
            var NcrFaultDTOlist = _vendorNcrRepository.GetNcrFaults();
            return View("ManageNCR", NcrFaultDTOlist);
        }
        public IActionResult ViewVendorNCRs()
        {
            var VendorNcrDTOlist = _vendorNcrRepository.GetVendorNcrs();
            return View(VendorNcrDTOlist);
        }

        [HttpPost]
        public IActionResult GetVendorNcrById([FromBody] int ncrId)
        {
            var VendorNcrDTO = _vendorNcrRepository.GetVendorNcrById(ncrId);

            if (VendorNcrDTO == null) return BadRequest(new { message = "NCR not found" });

            return Ok(VendorNcrDTO);
        }

        [HttpPost]
        public IActionResult SaveNewVendorNCR([FromBody] AddNewVendorNcrDTO addNewVendorNcrDTO)
        {
            if (ModelState.IsValid)
            {
                _vendorNcrRepository.SaveNewVendorNCR(addNewVendorNcrDTO);
                return Ok(new { message = "NCR created successfully" });
            }
            return BadRequest(new { message = "Something went wrong" });
        }

        [HttpPut]
        public IActionResult UpdateVendorNCR([FromBody] UpdateVendorNcrDTO updateVendorNcrDTO)
        {
            if (ModelState.IsValid)
            {
                _vendorNcrRepository.UpdateVendorNCR(updateVendorNcrDTO);
                return Ok(new { message = "NCR updated successfully" });
            }
            return BadRequest(new { message = "Something went wrong" });
        }

        [HttpDelete]
        public IActionResult DeleteNcr([FromBody] int ncrId)
        {
            _vendorNcrRepository.DeleteVendorNCR(ncrId);
            return Ok(new { message = "NCR deleted successfully" });
        }
    }
}
