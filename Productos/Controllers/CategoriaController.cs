using Productos.Dato;
using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productos.Controllers
{

    public class CategoriaController : Controller
    {
        CategoriaAdmin admin = new CategoriaAdmin();
        // GET: Categoria
        public ActionResult Index()
        {
            IEnumerable<Categoria> lista = admin.Consulta();
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
        public ActionResult Nuevo(Categoria modelo)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {

                admin.Guardar(modelo);
                ViewBag.mensaje = "Categoria Guardada";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",ex);
                return View();
            }
                      
        }

        public ActionResult Detalle(int id=0)
        {
            Categoria modelo = admin.Consultar(id);
            return View(modelo);
        }


      
        public ActionResult Modificar(int id=0)
        {           
            Categoria modelo = admin.Consultar(id);
            ViewBag.mensaje = "";
            return View (modelo);
        }

        public ActionResult Actualizar(Categoria modelo)
        {
           
            admin.Modificar(modelo);
            ViewBag.mensaje = "Categoria Modificada";            
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id = 0)
        {
            Categoria modelo = new Categoria()
            {
                ID=id
            };
            admin.Eliminar(modelo);
            IEnumerable<Categoria> lista = admin.Consulta();
            ViewBag.mensaje = "Categoria Eliminada";
            return View("Index",lista);
        }
    }
}