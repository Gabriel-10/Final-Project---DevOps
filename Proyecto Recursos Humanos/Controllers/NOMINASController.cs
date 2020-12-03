using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Recursos_Humanos.Models;
//using System.Collections.Generic.List;

namespace Proyecto_Recursos_Humanos.Controllers
{
    public class NOMINASController : Controller
    {
        private RecursosHumanosEntities1 db = new RecursosHumanosEntities1();

        // GET: NOMINAS
        public ActionResult Index()
        {
            return View(db.NOMINAS.ToList());
        }

        // GET: NOMINAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINAS nOMINAS = db.NOMINAS.Find(id);
            if (nOMINAS == null)
            {
                return HttpNotFound();
            }
            return View(nOMINAS);
        }

        // GET: NOMINAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NOMINAS/Create


        // AGREGAR LA NOMINA

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Nominas,Mes,Año,Monto")] NOMINAS nOMINAS)
        {
            if (ModelState.IsValid)
            {
                var nomina = (from n in db.EMPLEADOS
                              where n.Fecha_De_Ingreso.Month == nOMINAS.Mes && n.Fecha_De_Ingreso.Year == nOMINAS.Año
                              select n.Salario).Sum();

                nOMINAS.Monto = nomina;
                db.NOMINAS.Add(nOMINAS);
                db.SaveChanges();

                ViewBag.Total = nomina;
            }

            return View(nOMINAS);
        }

        // GET: NOMINAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINAS nOMINAS = db.NOMINAS.Find(id);
            if (nOMINAS == null)
            {
                return HttpNotFound();
            }
            return View(nOMINAS);
        }

        // POST: NOMINAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Nominas,Mes,Año,Monto")] NOMINAS nOMINAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOMINAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nOMINAS);
        }

        // GET: NOMINAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINAS nOMINAS = db.NOMINAS.Find(id);
            if (nOMINAS == null)
            {
                return HttpNotFound();
            }
            return View(nOMINAS);
        }

        // POST: NOMINAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOMINAS nOMINAS = db.NOMINAS.Find(id);
            db.NOMINAS.Remove(nOMINAS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
