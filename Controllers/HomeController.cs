using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using knjiznica.Models;
using Microsoft.EntityFrameworkCore;
using knjiznica.Data;

namespace knjiznica.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly KnjiznicaContext _context;
    public HomeController(ILogger<HomeController> logger, KnjiznicaContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var knjiznice = await _context.Knjiznice.ToListAsync();
        return View(knjiznice);
    }

    public IActionResult Privacy() // Home mapa Privacy.cshtml
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
