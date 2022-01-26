using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Razón Social")]
        [StringLength(256)]
        [Index("IX_Proveedores_RazonSocial", IsUnique = true)]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(12)]
        public string Cuil { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string NroTelefono { get; set; }


        public string Direccion { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Observacion { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}