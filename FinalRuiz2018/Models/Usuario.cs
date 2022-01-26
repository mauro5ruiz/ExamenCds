using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "E-Mail")]
        [StringLength(256)]
        [Index("IX_Usuarios_NombreUsuario", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto
        {
            get { return $"{Apellido}, {Nombres}"; }
        }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Foto { get; set; }
    }
}