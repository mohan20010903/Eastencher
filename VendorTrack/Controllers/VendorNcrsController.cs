using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorTrack.Data;
using VendorTrack.Models.DTOs;
using VendorTrack.Models.Entities;

namespace VendorTrack.Controllers
{
    public class VendorNcrsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public VendorNcrsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: VendorNcrs
        public async Task<IActionResult> Index()
        {
            var VendorNcrDTOlist = await _context.VendorNcr
                .Select(x => new VendorNcrDTO
                {
                    VendorNcrId = x.VendorNcrId,
                    NcrNumber = x.NcrNumber,
                    PartNumber = x.PartNumber,
                    Fault = x.Fault,
                    ReceivedDate = x.ReceivedDate,
                    ReceivedQuantity = x.ReceivedQuantity,
                    NonConformingQuantity = x.NonConformingQuantity,
                    VendorName = x.VendorName,
                    ContactName = x.ContactName,
                    ContactEmail = x.ContactEmail,
                })
                .ToListAsync();
            return View("ManageNCR", VendorNcrDTOlist);
        }

        // GET: VendorNcrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorNcr = await _context.VendorNcr
                .FirstOrDefaultAsync(m => m.VendorNcrId == id);
            if (vendorNcr == null)
            {
                return NotFound();
            }

            return View(vendorNcr);
        }

        // GET: VendorNcrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendorNcrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendorNcrId,NcrNumber,PartNumber,Fault,ReceivedDate,ReceivedQuantity,NonConformingQuantity,VendorName,ContactName,ContactEmail")] VendorNcr vendorNcr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorNcr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorNcr);
        }

        // GET: VendorNcrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorNcr = await _context.VendorNcr.FindAsync(id);
            if (vendorNcr == null)
            {
                return NotFound();
            }
            return View(vendorNcr);
        }

        // POST: VendorNcrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendorNcrId,NcrNumber,PartNumber,Fault,ReceivedDate,ReceivedQuantity,NonConformingQuantity,VendorName,ContactName,ContactEmail")] VendorNcr vendorNcr)
        {
            if (id != vendorNcr.VendorNcrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorNcr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorNcrExists(vendorNcr.VendorNcrId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vendorNcr);
        }

        // GET: VendorNcrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorNcr = await _context.VendorNcr
                .FirstOrDefaultAsync(m => m.VendorNcrId == id);
            if (vendorNcr == null)
            {
                return NotFound();
            }

            return View(vendorNcr);
        }

        // POST: VendorNcrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendorNcr = await _context.VendorNcr.FindAsync(id);
            if (vendorNcr != null)
            {
                _context.VendorNcr.Remove(vendorNcr);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorNcrExists(int id)
        {
            return _context.VendorNcr.Any(e => e.VendorNcrId == id);
        }
    }
}
