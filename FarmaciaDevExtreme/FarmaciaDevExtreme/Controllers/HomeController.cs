using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaDevExtreme.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        public ActionResult Direccion()
        {
            return View();
        }

        public ActionResult Factura()
        {
            return View();
        }
        public ActionResult Inventario()
        {
            return View();
        }

        public ActionResult Laboratorio()
        {
            return View();
        }
        public ActionResult Proveedor()
        {
            return View();
        }
        public ActionResult DetalleFactura()
        {
            return View();
        }

    }
}