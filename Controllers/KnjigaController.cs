using knjiznica.Data;
using knjiznica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace knjiznica.Controllers
{
    public class KnjigaController : Controller
    {
        private readonly KnjiznicaContext _context;
        public KnjigaController(KnjiznicaContext context) { _context = context; } // --->konstruktor i dependancy injection

        public async Task<IActionResult> PregledKnjiga()  // naziv cshtmla
        {
            var knjige = await _context.Knjige.ToListAsync();  
            return View(knjige); 
        }
        public async Task<IActionResult> PretragaKnjiga(string nazivKnjiznice)
        {
            if (string.IsNullOrEmpty(nazivKnjiznice))
            {
                return View(new List<KnjigaModel>());
            }

            var knjige = await _context.KnjiznicaKnjige
                                       .Where(kk => kk.Knjiznica != null && kk.Knjiznica.Naziv.Contains(nazivKnjiznice))
                                       .Select(kk => kk.Knjiga)
                                       .ToListAsync();

            return View(knjige); // Prikazuje rezultate u odgovarajućem View-u
        }
        [HttpGet]
        public async Task<IActionResult> PretraziKnjiznice(string term)
        {
            var prijedlozi = await _context.Knjiznice
                                           .Where(k => k.Naziv.Contains(term))
                                           .Select(k => k.Naziv)
                                           .ToListAsync();

            return Json(prijedlozi);
        }

    }
}
