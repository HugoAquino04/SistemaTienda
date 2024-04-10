using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("PedidoDetalle")]
    public class PedidoDetalle
    {
        public int PedidoDetalleId { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int ProductoId { get; set; }

        public decimal Precio { get; set; } = 0.10m;

        public decimal SubTotal { get; set; } = 0.10m;

        public decimal Descuento { get; set; } = 0.10m;

    }


}
