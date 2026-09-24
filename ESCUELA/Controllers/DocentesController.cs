
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESCUELA.Models;
using ESCUELA.Data;
using System.Security.Claims;

public class DocentesController : Controller
{
    private readonly EscuelaContext _context;

    public DocentesController(EscuelaContext context)
    {
        _context = context;
    }

    // GET: DOCENTES
    public async Task<IActionResult> Index()
    {
        var idDocente = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var docente = await _context.Docentes.FindAsync(idDocente);

        if (docente == null)
            return NotFound();

        var asignaciones = await _context.Docente_Asigatura_Grupos
            .Where(a => a.Id_docente == idDocente)
            .ToListAsync();

        ViewBag.TotalGrupos = asignaciones.Select(a => a.Id_grupo).Distinct().Count();
        ViewBag.TotalAsignaturas = asignaciones.Select(a => a.Id_asignatura).Distinct().Count();

        return View(docente);
    }

    // GET: DOCENTES/Details/5
    public async Task<IActionResult> Details(int? id_docente)
    {
        if (id_docente == null)
        {
            return NotFound();
        }

        var docente = await _context.Docentes
            .FirstOrDefaultAsync(m => m.Id_docente == id_docente);
        if (docente == null)
        {
            return NotFound();
        }

        return View(docente);
    }

    // GET: DOCENTES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DOCENTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id_docente,Numero_Empleado,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Usuario,Contrasena,Estatus")] Docente docente)
    {
        if (ModelState.IsValid)
        {
            _context.Add(docente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(docente);
    }

    // GET: DOCENTES/Edit/5
    public async Task<IActionResult> Edit(int? id_docente)
    {
        if (id_docente == null)
        {
            return NotFound();
        }

        var docente = await _context.Docentes.FindAsync(id_docente);
        if (docente == null)
        {
            return NotFound();
        }
        return View(docente);
    }

    // POST: DOCENTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id_docente, [Bind("Id_docente,Numero_Empleado,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Usuario,Contrasena,Estatus")] Docente docente)
    {
        if (id_docente != docente.Id_docente)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(docente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocenteExists(docente.Id_docente))
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
        return View(docente);
    }

    // GET: DOCENTES/Delete/5
    public async Task<IActionResult> Delete(int? id_docente)
    {
        if (id_docente == null)
        {
            return NotFound();
        }

        var docente = await _context.Docentes
            .FirstOrDefaultAsync(m => m.Id_docente == id_docente);
        if (docente == null)
        {
            return NotFound();
        }

        return View(docente);
    }

    // POST: DOCENTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id_docente)
    {
        var docente = await _context.Docentes.FindAsync(id_docente);
        if (docente != null)
        {
            _context.Docentes.Remove(docente);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DocenteExists(int? id_docente)
    {
        return _context.Docentes.Any(e => e.Id_docente == id_docente);
    }
}
