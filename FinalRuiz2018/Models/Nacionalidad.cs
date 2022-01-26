using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Nacionalidad
    {
        [Key]
        public int NacionalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Nacionalidades_Nombre")]
        [Display(Name = "Nacionalidad")]
        public string Nombre { get; set; }

        public virtual ICollection<Interprete> Interpretes { get; set; }
    }
}