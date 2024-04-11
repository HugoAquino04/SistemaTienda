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
    public class GrupoDescuentoController : Controller
    {
        private SistemaTiendaContext db = new SistemaTiendaContext();

        // GET: GrupoDescuento
        public ActionResult Index()
        {
            return View(db.grupoDescuentos.ToList());
        }

        // GET: GrupoDescuento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoDescuento grupoDescuento = db.grupoDescuentos.Find(id);
            if (grupoDescuento == null)
            {
                return HttpNotFound();
            }
            return View(grupoDescuento);
        }

        // GET: GrupoDescuento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoDescuento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoDescuentoId,Codigo,Descripcion,Estado,Porcentaje,FechaCreacion")] GrupoDescuento grupoDescuento)
        {
            if (ModelState.IsValid)
            {
                db.grupoDescuentos.Add(grupoDescuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoDescuento);
        }

        // GET: GrupoDescuento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoDescuento grupoDescuento = db.grupoDescuentos.Find(id);
            if (grupoDescuento == null)
            {
                return HttpNotFound();
            }
            return View(grupoDescuento);
        }

        // POST: GrupoDescuento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrupoDescuentoId,Codigo,Descripcion,Estado,Porcentaje,FechaCreacion")] GrupoDescuento grupoDescuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoDescuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoDescuento);
        }

        // GET: GrupoDescuento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoDescuento grupoDescuento = db.grupoDescuentos.Find(id);
            if (grupoDescuento == null)
            {
                return HttpNotFound();
            }
            return View(grupoDescuento);
        }

        // POST: GrupoDescuento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoDescuento grupoDescuento = db.grupoDescuentos.Find(id);
            db.grupoDescuentos.Remove(grupoDescuento);
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
