using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Generos_Descripcion")]
        [Display(Name = "Genero")]
        public string Descripcion { get; set; }

        public virtual ICollection<Dvd> Dvds { get; set; }
    }
}