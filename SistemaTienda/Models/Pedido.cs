using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("Pedido")]

    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]

        public DateTime FechaPedido { get; set; }

        public bool Estado { get; set; }

        public decimal Total { get; set; } = 0.10m;

        public decimal SubTotal { get; set; } = 0.10m;

        public decimal Descuento { get; set; } = 0.10m;

        //subida
    }
}