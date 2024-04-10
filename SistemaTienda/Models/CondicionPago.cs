using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("CondicionPago")]

    public class CondicionPago
    {
        [Key]
        public int CondicionPagoId { get; set; }

        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public int Dias { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}