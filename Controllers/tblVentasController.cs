using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC;

namespace MVC.Controllers
{
    public class tblVentasController : Controller
    {
        private EmpresaEntities1 db = new EmpresaEntities1();

        // GET: tblVentas
        public ActionResult Index()
        {
            return View(db.tblVentas.ToList());
        }

        // GET: tblVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVentas tblVentas = db.tblVentas.Find(id);
            if (tblVentas == null)
            {
                return HttpNotFound();
            }
            return View(tblVentas);
        }

        // GET: tblVentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idventa,nombre_cliente,cantidad,precio_total,fecha_salida")] tblVentas tblVentas)
        {
            if (ModelState.IsValid)
            {
                db.tblVentas.Add(tblVentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblVentas);
        }

        // GET: tblVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVentas tblVentas = db.tblVentas.Find(id);
            if (tblVentas == null)
            {
                return HttpNotFound();
            }
            return View(tblVentas);
        }

        // POST: tblVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idventa,nombre_cliente,cantidad,precio_total,fecha_salida")] tblVentas tblVentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblVentas);
        }

        // GET: tblVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVentas tblVentas = db.tblVentas.Find(id);
            if (tblVentas == null)
            {
                return HttpNotFound();
            }
            return View(tblVentas);
        }

        // POST: tblVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVentas tblVentas = db.tblVentas.Find(id);
            db.tblVentas.Remove(tblVentas);
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
