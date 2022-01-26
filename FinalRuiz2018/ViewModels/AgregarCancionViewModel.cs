using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.ViewModels
{
    public class AgregarCancionViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar una {0}")]
        [Display(Name = "Canción")]
        public int CancionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Debe ingresar valor en {0} entre {1} y {2}")]
        public TimeSpan Duracion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }
    }
}