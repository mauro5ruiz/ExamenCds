using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Interprete
    {
        [Key]
        public int InterpreteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Interprete_Apellido_Nombres_NacionalidadId", Order = 1, IsUnique = true)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Interprete_Apellido_Nombres_NacionalidadId", Order = 2, IsUnique = true)]
        public string Nombres { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto
        {
            get { return $"{Apellido} {Nombres}"; }
        }

        [Required(ErrorMessage = "El campo {0} es requirido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una nacionalidad")]
        [Index("IX_Interprete_Apellido_Nombres_NacionalidadId", Order = 3, IsUnique = true)]
        [Display(Name = "Nacionalidad")]
        public int NacionalidadId { get; set; }

        public virtual Nacionalidad Nacionalidad { get; set; }

        public virtual ICollection<Cd> Cds { get; set; }
    }
}