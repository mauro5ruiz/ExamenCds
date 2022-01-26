using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Index("IX_Productos_TipoProductoId", IsUnique = true, Order = 2)]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name = "Tipo de Dísco")]
        public int TipoProductoId { get; set; }

        public virtual TipoProducto TipoProducto { get; set; }

        public virtual ICollection<Cd> Cds { get; set; }
        public virtual ICollection<Dvd> Dvds { get; set; }
        public virtual ICollection<DetallesCompra> DetallesCompra { get; set; }
        public virtual ICollection<DetallesCompraTmp> DetallesCompraTmps { get; set; }
    }
}