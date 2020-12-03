using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Recursos_Humanos.Models;

namespace Proyecto_Recursos_Humanos.Controllers
{
    public class EMPLEADOSController : Controller
    {
        private RecursosHumanosEntities1 db = new RecursosHumanosEntities1();

        // GET: EMPLEADOS
        public ActionResult Index()
        {
            var eMPLEADOS = db.EMPLEADOS.Include(e => e.CARGOS).Include(e => e.DEPARTAMENTOS);
            return View(eMPLEADOS.ToList());
        }

        // GET: EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cargo = new SelectList(db.CARGOS, "Id_Car", "Cargo");
            ViewBag.Id_Departamento = new SelectList(db.DEPARTAMENTOS, "Id_Dep", "Departamento");
            return View();
        }

        // POST: EMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Apellido,Telefono,Email,Id_Departamento,Id_Cargo,Fecha_De_Ingreso,Salario")] EMPLEADOS eMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOS.Add(eMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cargo = new SelectList(db.CARGOS, "Id_Car", "Cargo", eMPLEADOS.Id_Cargo);
            ViewBag.Id_Departamento = new SelectList(db.DEPARTAMENTOS, "Id_Dep", "Departamento", eMPLEADOS.Id_Departamento);
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cargo = new SelectList(db.CARGOS, "Id_Car", "Cargo", eMPLEADOS.Id_Cargo);
            ViewBag.Id_Departamento = new SelectList(db.DEPARTAMENTOS, "Id_Dep", "Departamento", eMPLEADOS.Id_Departamento);
            return View(eMPLEADOS);
        }

        // POST: EMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Apellido,Telefono,Email,Id_Departamento,Id_Cargo,Fecha_De_Ingreso,Salario")] EMPLEADOS eMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cargo = new SelectList(db.CARGOS, "Id_Car", "Cargo", eMPLEADOS.Id_Cargo);
            ViewBag.Id_Departamento = new SelectList(db.DEPARTAMENTOS, "Id_Dep", "Departamento", eMPLEADOS.Id_Departamento);
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADOS);
        }

        // POST: EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            db.EMPLEADOS.Remove(eMPLEADOS);
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
