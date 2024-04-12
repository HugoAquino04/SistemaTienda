using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTienda.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categorias Categorias { get; set; }

        [Display(Name = "Unidad Medida")]
        public int UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaCreacion { get; set; }

        public bool Estado { get; set; }

        [Display(Name = "Precio Compra")]
        public decimal PrecioCompra { get; set; } = 0.10m;
    }
}