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
    public class ClienteController : Controller
    {
        private SistemaTiendaContext db = new SistemaTiendaContext();

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = db.clientes.Include(c => c.condicionPago).Include(c => c.grupoDescuento);
            return View(clientes.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.CondicionPagoId = new SelectList(db.CondicionPago, "CondicionPagoId", "Codigo");
            ViewBag.GrupoDescuentoId = new SelectList(db.grupoDescuentos, "GrupoDescuentoId", "Codigo");
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Codigo,Nombre,Apellidos,GrupoDescuentoId,CondicionPagoId,Estado,FechaCreacion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondicionPagoId = new SelectList(db.CondicionPago, "CondicionPagoId", "Codigo", cliente.CondicionPagoId);
            ViewBag.GrupoDescuentoId = new SelectList(db.grupoDescuentos, "GrupoDescuentoId", "Codigo", cliente.GrupoDescuentoId);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondicionPagoId = new SelectList(db.CondicionPago, "CondicionPagoId", "Codigo", cliente.CondicionPagoId);
            ViewBag.GrupoDescuentoId = new SelectList(db.grupoDescuentos, "GrupoDescuentoId", "Codigo", cliente.GrupoDescuentoId);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Codigo,Nombre,Apellidos,GrupoDescuentoId,CondicionPagoId,Estado,FechaCreacion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicionPagoId = new SelectList(db.CondicionPago, "CondicionPagoId", "Codigo", cliente.CondicionPagoId);
            ViewBag.GrupoDescuentoId = new SelectList(db.grupoDescuentos, "GrupoDescuentoId", "Codigo", cliente.GrupoDescuentoId);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.clientes.Find(id);
            db.clientes.Remove(cliente);
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
