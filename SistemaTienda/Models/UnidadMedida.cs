using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("UnidadMedida")]

    public class UnidadMedida
    {
        [Key]

        public int UnidadMediaId { get; set; }

        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        //modificar
    }
}