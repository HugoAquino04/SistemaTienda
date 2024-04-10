using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLength(15)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellidos { get; set; }

        public int GrupoDescuentoId { get; set; }

        public GrupoDescuento grupoDescuento { get; set; }

        public int CondicionPagoId { get; set; }
        public CondicionPago condicionPago { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}