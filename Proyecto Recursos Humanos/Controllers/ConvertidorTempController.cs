using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Recursos_Humanos.Models;

namespace Proyecto_Recursos_Humanos.Controllers
{
    public class ConvertidorTempController : Controller
    {
        // GET: ConvertidorTemp
        public ActionResult Index()
        {
            return View(new Temperatura());
        }

        [HttpPost]

        public ActionResult Index(Temperatura temp, string convertir)
        {
            if (convertir == "cantidad")
            {
                // farenheit a celsius
                temp.total = (temp.cantidad - 32) * 5 / 9;
            }
            else
            {
                // celsius a farenheit
                temp.total = ((temp.cantidad * 9) / 5) + 32;
            }

            return View(temp);
        }
    }
}