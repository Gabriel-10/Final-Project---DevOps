using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Recursos_Humanos.Models;

namespace Proyecto_Recursos_Humanos.Controllers
{
    public class CalcularController : Controller
    {
        // GET: Calcular
        public ActionResult Index()
        {
            return View(new Calculadora());
        }

        [HttpPost]

        public ActionResult Index(Calculadora clc, string calculate)
        {
            if(calculate == "sumar")
            {
                clc.total = clc.numero1 + clc.numero2;
            }
            else if(calculate == "restar")
            {
               clc.total = clc.numero1 - clc.numero2;
            }
            else if (calculate == "multiplicar")
            {
                clc.total = clc.numero1 * clc.numero2;
            }
            else
            {
                clc.total = clc.numero1 / clc.numero2;
            }


            return View(clc);
        }
    }
}