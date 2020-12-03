using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Recursos_Humanos.Models;

namespace Proyecto_Recursos_Humanos.Controllers
{
    public class ConversorMonedasController : Controller
    {
        // GET: ConversorMonedas
        public ActionResult Index()
        {
            return View(new Monedas());
        }

        [HttpPost]

        public ActionResult Index(Monedas clc, string convertir)
        {
            if (convertir == "valor")
            {
                clc.total = clc.valor / 58.59;
            }
            else
            {
                clc.total = clc.valor * 58.59;
            }

            return View(clc);
        }
    }
}