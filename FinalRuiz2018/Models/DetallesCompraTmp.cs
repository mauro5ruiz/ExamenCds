using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class DetallesCompraTmp
    {
        [Key]
        public int DetallesCompraTmpId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(256, ErrorMessage = "El campo {0} debe tener como maximo {1} caracteres")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener como maximo {1} caracteres")]
        [Display(Name = "Producto")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar el valor del {0} entre {1} y {2}")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar el valor de la {0} entre {1} y {2}")]
        public double Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Total { get { return Precio * (decimal)Cantidad; } }

        public virtual Producto Producto { get; set; }
    }
}