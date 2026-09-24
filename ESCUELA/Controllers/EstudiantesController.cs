
using ESCUELA.Data;
using ESCUELA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class EstudiantesController : Controller
{
    private readonly EscuelaContext _context;

    public EstudiantesController(EscuelaContext context)
    {
        _context = context;
    }

    // GET: ESTUDIANTES
    public async Task<IActionResult> Index()
    {
        var estudiantes = await _context.Estudiantes
            .ToListAsync();

        return View(estudiantes);
    }

    // GET: ESTUDIANTES/Details/5
    public async Task<IActionResult> Details(int? id_estudiante)
    {
        if (id_estudiante == null)
        {
            return NotFound();
        }

        var estudiante = await _context.Estudiantes
            .FirstOrDefaultAsync(m => m.Id_estudiante == id_estudiante);
        if (estudiante == null)
        {
            return NotFound();
        }

        return View(estudiante);
    }

    // GET: ESTUDIANTES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ESTUDIANTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id_estudiante,Matricula,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Usuario,Contrasena,estatus")] Estudiante estudiante)
    {
        if (ModelState.IsValid)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(estudiante);
    }

    // GET: ESTUDIANTES/Edit/5
    public async Task<IActionResult> Edit(int? id_estudiante)
    {
        if (id_estudiante == null)
        {
            return NotFound();
        }

        var estudiante = await _context.Estudiantes.FindAsync(id_estudiante);
        if (estudiante == null)
        {
            return NotFound();
        }
        return View(estudiante);
    }

    // POST: ESTUDIANTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id_estudiante, [Bind("Id_estudiante,Matricula,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Usuario,Contrasena,estatus")] Estudiante estudiante)
    {
        if (id_estudiante != estudiante.Id_estudiante)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(estudiante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(estudiante.Id_estudiante))
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
        return View(estudiante);
    }

    // GET: ESTUDIANTES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estudiante = await _context.Estudiantes
            .FirstOrDefaultAsync(e => e.Id_estudiante == id);

        if (estudiante == null)
        {
            return NotFound();
        }

        return View(estudiante);
    }


    // POST: ESTUDIANTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id_estudiante)
    {
        var estudiante = await _context.Estudiantes.FindAsync(id_estudiante);
        if (estudiante != null)
        {
            _context.Estudiantes.Remove(estudiante);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EstudianteExists(int? id_estudiante)
    {
        return _context.Estudiantes.Any(e => e.Id_estudiante == id_estudiante);
    }
}
