using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTienda.ViewsModels
{
    public class PedidoDetalleFormViewModel
    {
        public PedidoDetalle PedidoDetalle { get; set; }
        public IEnumerable<Producto> Productos { get; set; }

    }
}