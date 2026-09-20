using CBTSWE2_TP02.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CBTSWE2_TP02.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly CBTSWE2_TP02Context _context;
        public RelatorioController(CBTSWE2_TP02Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bls = await _context.BLs
                .Include(b => b.ContainersOBJs)
                .ToListAsync();

            return View(bls);
        }
    }
}
