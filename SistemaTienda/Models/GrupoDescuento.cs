using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("GrupoDescuento")]
    public class GrupoDescuento
    {

        [Key]
        public int GrupoDescuentoId { get; set; }

        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public int Porcentaje { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaCreacion { get; set; }
    }
}