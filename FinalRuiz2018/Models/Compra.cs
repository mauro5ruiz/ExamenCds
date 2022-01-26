using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<DetallesCompra> DetallesCompra { get; set; }
    }
}