using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
   
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaFactura { get; set; }

        public bool Estado { get; set; }

        public decimal Total { get; set; } = 0.10m;

        public decimal SubTotal { get; set; } = 0.10m;

        public decimal Descuento { get; set; } = 0.10m;
    }
}