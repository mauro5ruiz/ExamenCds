using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FinalRuiz2018.Models;

namespace FinalRuiz2018.ViewModels
{
    public class CompraViewModel
    {
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

        public List<DetallesCompraTmp> Detalles { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double CantidadTotal { get { return Detalles == null ? 0 : Detalles.Sum(d => d.Cantidad); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioTotal { get { return Detalles == null ? 0 : Detalles.Sum(d => d.Precio); } }
    }
}