using knjiznica.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace knjiznica.Controllers
{
    public class KnjiznicaController : Controller
    {
        private readonly KnjiznicaContext _context;
        public KnjiznicaController(KnjiznicaContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var knjiznice = await _context.Knjiznice.ToListAsync();
            return View(knjiznice);
        }

        public async Task<IActionResult> KnjiznicaDetails(int Id)
        {
            var knjiznice = await _context.Knjiznice.ToListAsync( );
            var knjiznica = knjiznice.FirstOrDefault(k => k.Id == Id);
            return View(knjiznica);
        }
        public async Task<IActionResult> Knjiznice()
        {
            var knjiznice = await _context.Knjiznice.ToListAsync();
            return View(knjiznice);
        }

    }
}
