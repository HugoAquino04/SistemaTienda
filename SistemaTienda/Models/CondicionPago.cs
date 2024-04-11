using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaCreacion { get; set; }
        //
    }
}