using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentasWeb.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Obtener()
        {
            List<Rol> olista = CD_Rol.Instancia.ObtenerRol();
           
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(Rol objeto)
        {
            bool respuesta = false;

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = false;

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}