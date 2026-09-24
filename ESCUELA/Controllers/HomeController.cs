using System.Diagnostics;
using ESCUELA.Data;
using ESCUELA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESCUELA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EscuelaContext _context;

        public HomeController(ILogger<HomeController> logger, EscuelaContext context)
        {
            _logger = logger;
            _context = context;
        }

        // "/" es el panel de administración. Cada rol termina en su propio panel;
        // quien no ha iniciado sesión se manda a Login.
       public async Task<IActionResult> Index()
{
    Console.WriteLine("AUTENTICADO: " + User.Identity?.IsAuthenticated);
    Console.WriteLine("USUARIO: " + User.Identity?.Name);
    Console.WriteLine("ADMIN: " + User.IsInRole("Admin"));
    Console.WriteLine("DOCENTE: " + User.IsInRole("Docente"));
    Console.WriteLine("ESTUDIANTE: " + User.IsInRole("Estudiante"));

    if (User.Identity == null || !User.Identity.IsAuthenticated)
    {
        return RedirectToAction(
            "Login",
            "Account",
            new { returnUrl = Url.Action("Index", "Home") });
    }

    if (User.IsInRole("Docente"))
        return RedirectToAction("Index", "Docente");

    if (User.IsInRole("Estudiante"))
        return RedirectToAction("Index", "Estudiante");

    if (User.IsInRole("Admin"))
    {
        ViewBag.TotalEstudiantes = await _context.Estudiantes.CountAsync();
        ViewBag.TotalDocentes = await _context.Docentes.CountAsync();
        ViewBag.TotalGrupos = await _context.Grupos.CountAsync();
        ViewBag.TotalAsignaturas = await _context.Asignaturas.CountAsync();

        return View();
    }

    return RedirectToAction("AccessDenied", "Account");
}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
