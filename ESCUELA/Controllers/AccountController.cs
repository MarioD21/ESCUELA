using ESCUELA.Data;
using ESCUELA.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ESCUELA.Controllers
{
    public class AccountController : Controller
    {
        private readonly EscuelaContext _context;

        public AccountController(EscuelaContext context)
        {
            _context = context;
        }

    
[HttpGet]
public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(model);

            // =========================================================
            // BUSCAR ADMINISTRADOR
            // =========================================================

            var admin = await _context.Admins
                .FirstOrDefaultAsync(a =>
                    a.Usuario == model.Usuario &&
                    a.Contrasena == model.Contrasena);

            if (admin != null)
            {
                if (!admin.Estatus)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "El usuario se encuentra inactivo");

                    return View(model);
                }

                var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.Name,
                admin.Usuario),

            new Claim(
                ClaimTypes.NameIdentifier,
                admin.Id_admin.ToString()),

            new Claim(
                ClaimTypes.Role,
                "Admin"),

            new Claim(
                "NombreCompleto",
                $"{admin.Nombre} {admin.ApellidoPaterno} {admin.ApellidoMaterno}")
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                    });

                if (!string.IsNullOrEmpty(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }


            // =========================================================
            // BUSCAR DOCENTE
            // =========================================================

            var docente = await _context.Docentes
                .FirstOrDefaultAsync(d =>
                    d.Usuario == model.Usuario &&
                    d.Contrasena == model.Contrasena);

            if (docente != null)
            {
                if (!docente.Estatus)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "El usuario se encuentra inactivo");

                    return View(model);
                }

                var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.Name,
                docente.Usuario),

            new Claim(
                ClaimTypes.NameIdentifier,
                docente.Id_docente.ToString()),

            new Claim(
                ClaimTypes.Role,
                "Docente"),

            new Claim(
                "NombreCompleto",
                $"{docente.Nombre} {docente.ApellidoPaterno} {docente.ApellidoMaterno}")
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                    });

                if (!string.IsNullOrEmpty(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }


            // =========================================================
            // BUSCAR ESTUDIANTE
            // =========================================================

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(e =>
                    e.Usuario == model.Usuario &&
                    e.Contrasena == model.Contrasena);

            if (estudiante != null)
            {
                if (!estudiante.estatus)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "El usuario se encuentra inactivo");

                    return View(model);
                }

                var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.Name,
                estudiante.Usuario),

            new Claim(
                ClaimTypes.NameIdentifier,
                estudiante.Id_estudiante.ToString()),

            new Claim(
                ClaimTypes.Role,
                "Estudiante"),

            new Claim(
                "NombreCompleto",
                $"{estudiante.Nombre} {estudiante.ApellidoPaterno} {estudiante.ApellidoMaterno}")
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                    });

                if (!string.IsNullOrEmpty(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }


            // =========================================================
            // NO ENCONTRADO
            // =========================================================

            ModelState.AddModelError(
                string.Empty,
                "Usuario o contraseña incorrectos");

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Rol == "Docente")
            {
                var usuarioExistente = await _context.Docentes
                    .AnyAsync(d => d.Usuario == model.Usuario);

                if (usuarioExistente)
                {
                    ModelState.AddModelError(nameof(model.Usuario), "Ese usuario ya está registrado");
                    return View(model);
                }

                var docente = new Docente
                {
                    Numero_Empleado = model.Numero_Empleado ?? 0,
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Correo = model.Correo,
                    Usuario = model.Usuario,
                    Contrasena = model.Contrasena,
                    Estatus = true
                };

                _context.Docentes.Add(docente);
                await _context.SaveChangesAsync();
            }
            else if (model.Rol == "Estudiante")
            {
                var usuarioExistente = await _context.Estudiantes
                    .AnyAsync(e => e.Usuario == model.Usuario);

                if (usuarioExistente)
                {
                    ModelState.AddModelError(nameof(model.Usuario), "Ese usuario ya está registrado");
                    return View(model);
                }

                var estudiante = new Estudiante
                {
                    Matricula = model.Matricula ?? string.Empty,
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Correo = model.Correo,
                    Usuario = model.Usuario,
                    Contrasena = model.Contrasena,
                    estatus = true
                };

                _context.Estudiantes.Add(estudiante);
                await _context.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Selecciona un rol válido");
                return View(model);
            }

            TempData["RegistroExitoso"] = "Cuenta creada correctamente. Ya puedes iniciar sesión.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
