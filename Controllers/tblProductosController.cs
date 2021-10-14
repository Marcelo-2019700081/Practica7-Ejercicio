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
    public class tblProductosController : Controller
    {
        private EmpresaEntities2 db = new EmpresaEntities2();

        // GET: tblProductos
        public ActionResult Index()
        {
            return View(db.tblProductos.ToList());
        }

        // GET: tblProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductos tblProductos = db.tblProductos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // GET: tblProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,costo,marca")] tblProductos tblProductos)
        {
            if (ModelState.IsValid)
            {
                db.tblProductos.Add(tblProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblProductos);
        }

        // GET: tblProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductos tblProductos = db.tblProductos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // POST: tblProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,costo,marca")] tblProductos tblProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblProductos);
        }

        // GET: tblProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductos tblProductos = db.tblProductos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // POST: tblProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProductos tblProductos = db.tblProductos.Find(id);
            db.tblProductos.Remove(tblProductos);
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
