using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Cd
    {
        [Key]
        public int CdId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Display(Name = "Estilo")]
        public int EstiloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Index("IX_Cd_InterpreteId_Nombre", Order = 1, IsUnique = true)]
        [Display(Name = "Interprete")]
        public int InterpreteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Pistas { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Cd_InterpreteId_Nombre", Order = 2, IsUnique = true)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Año Grabación")]
        public int AñoGrabacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Duracion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe estar entre {1} y {2}")]
        [Display(Name = "Precio Costo")]
        public decimal PrecioCosto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe estar entre {1} y {2}")]
        [Display(Name = "Precio Venta")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        public virtual Estilo Estilo { get; set; }
        public virtual Interprete Interprete { get; set; }
        public virtual Producto Producto { get; set; }

        public virtual ICollection<Cancion> Canciones { get; set; }
    }
}