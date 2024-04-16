using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTienda.ViewsModels
{
    public class PedidoFormViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<Cliente> Cliente { get; set; }
        public PedidoDetalleFormViewModel Tabla { get; set; }
        public List<PedidoDetalleFormViewModel> Productos { get; set; }

    }
}