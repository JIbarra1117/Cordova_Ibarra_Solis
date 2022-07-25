using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentasWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Cliente> oListaCliente = CD_Cliente.Instancia.ObtenerClientes();
            return Json(new { data = oListaCliente }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Cliente objeto)
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