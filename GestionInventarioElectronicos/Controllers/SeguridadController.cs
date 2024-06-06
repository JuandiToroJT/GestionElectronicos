using GestionInventarioElectronicos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioElectronicos.Controllers
{
    public class SeguridadController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (BaseDatosSimulada.Usuarios.Exists(x => x.UsuarioId == model.Usuario && x.Clave == model.Clave))
                {
                    BaseDatosSimulada.UsuarioSesion = BaseDatosSimulada.Usuarios.Find(x => x.UsuarioId == model.Usuario && x.Clave == model.Clave);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "Nombre de usuario o clave incorrectos.");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (BaseDatosSimulada.Usuarios.Exists(x => x.UsuarioId == model.Usuario))
                    ModelState.AddModelError(string.Empty, "El usuario ya existe.");
                else
                {
                    BaseDatosSimulada.Usuarios.Add(new Usuario() { UsuarioId = model.Usuario, Clave = model.Clave, Admin = false });
                    return RedirectToAction("Login", "Seguridad");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            BaseDatosSimulada.UsuarioSesion = null;
            return RedirectToAction("Login", "Seguridad");
        }
    }
}
