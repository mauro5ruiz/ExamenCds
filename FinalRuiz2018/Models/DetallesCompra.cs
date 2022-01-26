using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class DetallesCompra
    {
        [Key]
        public int DetalleCompraId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CompraId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener como máximo {1} carácteres")]
        [Display(Name = "Product")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar el valor del {0} entre {1} y {2}")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar el valor del {0} entre {1} y {2}")]
        public double Cantidad { get; set; }

        public virtual Compra Compra { get; set; }

        public virtual Producto Producto { get; set; }
    }
}