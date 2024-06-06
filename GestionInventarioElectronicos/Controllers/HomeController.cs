using GestionInventarioElectronicos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioElectronicos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inventario()
        {
            List<Producto> productos = BaseDatosSimulada.ArbolBinario.RecorrerPreOrden();
            return View(productos);
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Venta()
        {
            return View();
        }

        public IActionResult Historial()
        {
            return View(BaseDatosSimulada.Ventas.RecorrerPreOrden());
        }

        [HttpPost]
        public IActionResult Registro(Producto nuevoProducto)
        {
            if (ModelState.IsValid)
            {
                if (BaseDatosSimulada.ArbolBinario.BuscarProductos(nuevoProducto.Nombre).Any())
                    ModelState.AddModelError(string.Empty, "Producto ya existente.");
                else
                {
                    nuevoProducto.Id = BaseDatosSimulada.ArbolBinario.ContarProductos() + 1;
                    BaseDatosSimulada.ArbolBinario.Insertar(nuevoProducto);
                    return RedirectToAction("Inventario");
                }
            }
            return View(nuevoProducto);
        }

        [HttpPost]
        public IActionResult Venta(Venta nuevaVenta)
        {
            if (ModelState.IsValid)
            {
                Producto productoVenta = BaseDatosSimulada.ArbolBinario.Buscar(nuevaVenta.ProductoId);

                int totalStock = productoVenta.Cantidad;
                int resta = totalStock - nuevaVenta.Cantidad;
                if (resta < 0)
                    ModelState.AddModelError(string.Empty, "No hay suficientes productos disponibles.");
                else if (resta == 0)
                {
                    nuevaVenta.Id = BaseDatosSimulada.Ventas.ContarVentas() + 1;
                    nuevaVenta.Nombre = productoVenta.Nombre;
                    BaseDatosSimulada.Ventas.Insertar(nuevaVenta);
                    BaseDatosSimulada.ArbolBinario.Eliminar(nuevaVenta.ProductoId);
                    return RedirectToAction("Index");
                }
                else
                {
                    nuevaVenta.Id = BaseDatosSimulada.Ventas.ContarVentas() + 1;
                    nuevaVenta.Nombre = productoVenta.Nombre;
                    BaseDatosSimulada.Ventas.Insertar(nuevaVenta);
                    productoVenta.Cantidad = resta;
                    return RedirectToAction("Index");
                }
            }
            return View(nuevaVenta);
        }

        [HttpGet]
        public IActionResult Buscar(string query)
        {
            List<Producto> productos = BaseDatosSimulada.ArbolBinario.BuscarProductos(query, query, query);
            return View("Inventario", productos);
        }
    }
}
