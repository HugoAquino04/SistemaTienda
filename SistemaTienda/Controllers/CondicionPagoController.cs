using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaTienda.DataBase;
using SistemaTienda.Models;

namespace SistemaTienda.Controllers
{
    public class CondicionPagoController : Controller
    {
        private SistemaTiendaContext db = new SistemaTiendaContext();

        // GET: CondicionPago
        public ActionResult Index()
        {
            return View(db.CondicionPago.ToList());
        }

        // GET: CondicionPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionPago condicionPago = db.CondicionPago.Find(id);
            if (condicionPago == null)
            {
                return HttpNotFound();
            }
            return View(condicionPago);
        }

        // GET: CondicionPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicionPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CondicionPagoId,Codigo,Descripcion,Estado,Dias,FechaCreacion")] CondicionPago condicionPago)
        {
            if (ModelState.IsValid)
            {
                db.CondicionPago.Add(condicionPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicionPago);
        }

        // GET: CondicionPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionPago condicionPago = db.CondicionPago.Find(id);
            if (condicionPago == null)
            {
                return HttpNotFound();
            }
            return View(condicionPago);
        }

        // POST: CondicionPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CondicionPagoId,Codigo,Descripcion,Estado,Dias,FechaCreacion")] CondicionPago condicionPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicionPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicionPago);
        }

        // GET: CondicionPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionPago condicionPago = db.CondicionPago.Find(id);
            if (condicionPago == null)
            {
                return HttpNotFound();
            }
            return View(condicionPago);
        }

        // POST: CondicionPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondicionPago condicionPago = db.CondicionPago.Find(id);
            db.CondicionPago.Remove(condicionPago);
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
