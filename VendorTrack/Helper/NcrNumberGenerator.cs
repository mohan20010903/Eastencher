using Microsoft.EntityFrameworkCore;
using VendorTrack.Data;

namespace VendorTrack.Helper
{
    public class NcrNumberGenerator : INcrNumberGenerator
    {
        private readonly ApplicationDBContext _context;
        public NcrNumberGenerator(ApplicationDBContext context)
        {
            _context = context;
        }
        public string GenerateNcrNumber()
        {
            int lastnumber = (_context.Counters.Max(c => (int?)c.LastGeneratedNumber) ?? 0) + 1;
            string ncrNumber = $"NCR-{DateTime.Now:yy}-{lastnumber}";
            UpdateCounter();
            return ncrNumber;
        }

        public void UpdateCounter()
        {
            var counter = _context.Counters
                .Where(x => x.Reference == "NCR")
                .FirstOrDefault();

            if (counter == null) return;
            counter.LastGeneratedNumber += 1;
            _context.SaveChanges();
        }
    }
}
