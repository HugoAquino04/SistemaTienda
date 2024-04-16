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
using SistemaTienda.ViewsModels;

namespace SistemaTienda.Controllers
{
    public class PedidoController : Controller
    {
        private SistemaTiendaContext context = new SistemaTiendaContext();
        private int id;

        public PedidoController()
        {
            context = new SistemaTiendaContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }

        public int GetId()
        {
            return id;
        }

        // GET: Pedido
        public ActionResult Index(int id)
        {
             var pedido = context.Pedido.Include(c=>c.Cliente).Where(c => c.ClienteId == id).ToList();
            if (pedido.Count == 0) 
            {
                pedido.Add(new Pedido
                {
                    ClienteId = id
                });
            }
            return View(pedido);
        }

        public ActionResult Crear(int id)
        {
            var cliente = context.Pedido.FirstOrDefault(c => c.ClienteId == id);
            var clientes = context.Pedido.ToList();

            var viewModel = new PedidoFormViewModel
            {
                Pedido = new Pedido(),
                Clientes = clientes,
                Productos = new List<PedidoDetalleFormViewModel>()
            };
            viewModel.Pedido.ClienteId = cliente.ClienteId;
            viewModel.Pedido.FechaPedido = DateTime.Now;

            Session["viewOrden"] = viewModel;
            return View("OrdenForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(context.clientes, "ClienteId", "Codigo");
            return View();
        }

        // POST: Pedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,ClienteId,FechaCreacion,FechaPedido,Estado,Total,SubTotal,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                context.Pedido.Add(pedido);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(context.clientes, "ClienteId", "Codigo", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(context.clientes, "ClienteId", "Codigo", pedido.ClienteId);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,ClienteId,FechaCreacion,FechaPedido,Estado,Total,SubTotal,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                context.Entry(pedido).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(context.clientes, "ClienteId", "Codigo", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = context.Pedido.Find(id);
            context.Pedido.Remove(pedido);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
