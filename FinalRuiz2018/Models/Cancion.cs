using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Cancion
    {
        [Key]
        public int CancionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Cancion_CdId_Nombre", IsUnique = true, Order = 2)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public TimeSpan Duracion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Display(Name = "Cd")]
        [Index("IX_Cancion_CdId_Nombre", IsUnique = true, Order = 1)]
        public int CdId { get; set; }

        public virtual Cd Cd { get; set; }
    }
}