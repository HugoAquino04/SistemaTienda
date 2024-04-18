using SistemaTienda.DataBase;
using SistemaTienda.Models;
using SistemaTienda.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SistemaTienda.Controllers
{
    public class PedidoController : Controller
    {
        private SistemaTiendaContext _context;
        // GET: Pedido

        public PedidoController()
        {
            _context = new SistemaTiendaContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var Pedido = _context.Pedido.ToList();
            return View(Pedido);
        }

        public ActionResult Crear(int id)
        {
            var clientes = _context.clientes.Where(c => c.Estado == true).ToList();
            var viewModel = new PedidoFormViewModel
            {
                Pedido = new Pedido(),
                Cliente = clientes,
                Productos = new List<PedidoDetalleFormViewModel>()

            };
            viewModel.Pedido.FechaPedido = DateTime.Now;
            return View("PedidoForm", viewModel);
        }
    }
}