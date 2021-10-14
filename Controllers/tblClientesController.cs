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
    public class tblClientesController : Controller
    {
        private EmpresaEntities db = new EmpresaEntities();

        // GET: tblClientes
        public ActionResult Index()
        {
            return View(db.tblClientes.ToList());
        }

        // GET: tblClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClientes tblClientes = db.tblClientes.Find(id);
            if (tblClientes == null)
            {
                return HttpNotFound();
            }
            return View(tblClientes);
        }

        // GET: tblClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,direccion,telefono,email,edad")] tblClientes tblClientes)
        {
            if (ModelState.IsValid)
            {
                db.tblClientes.Add(tblClientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblClientes);
        }

        // GET: tblClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClientes tblClientes = db.tblClientes.Find(id);
            if (tblClientes == null)
            {
                return HttpNotFound();
            }
            return View(tblClientes);
        }

        // POST: tblClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,direccion,telefono,email,edad")] tblClientes tblClientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblClientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblClientes);
        }

        // GET: tblClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClientes tblClientes = db.tblClientes.Find(id);
            if (tblClientes == null)
            {
                return HttpNotFound();
            }
            return View(tblClientes);
        }

        // POST: tblClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblClientes tblClientes = db.tblClientes.Find(id);
            db.tblClientes.Remove(tblClientes);
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
