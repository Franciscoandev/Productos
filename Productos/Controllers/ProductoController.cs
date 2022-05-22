using Productos.Dato;
using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productos.Controllers
{
    public class ProductoController : Controller
    {
        ProductoAdmin admin = new ProductoAdmin();
        // GET: Producto
        public ActionResult Index()
        {
            IEnumerable<Producto> lista = admin.Consultar();
            ViewBag.mensaje = "";
            return View(lista);
        }

        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(Producto modelo)
        {
            if (!ModelState.IsValid)
                return View();
                try
                {

                    admin.Guardar(modelo);
                    ViewBag.mensaje = "Producto Guardado";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex);
                    return View();
                }

            admin.Guardar(modelo);
            ViewBag.mensaje = "Producto Guardado";
            return View("Guardar", modelo);
        }

        public ActionResult Detalle(int id=0)
        {
            Producto modelo = admin.Consultar(id);
            ViewBag.mensaje = "";
            return View(modelo);
        }

       
        public ActionResult Modificar(int id=0)
        {
            Producto modelo = admin.Consultar(id);
            ViewBag.mensaje = "";
            return View(modelo);
        }

        public ActionResult Actualizar(Producto modelo)
        {
           
            admin.Modificar(modelo);
            ViewBag.mensaje = "Producto Modificado";
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id = 0)
        {
            Producto modelo = new Producto()
            {
                ID=id
            };
            admin.Eliminar(modelo);
            IEnumerable<Producto> lista = admin.Consultar();
            ViewBag.mensaje = "Producto Eliminado";
            return View("Index",lista);
        }

    }
}