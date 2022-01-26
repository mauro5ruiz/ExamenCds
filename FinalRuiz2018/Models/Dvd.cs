using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class Dvd
    {
        [Key]
        public int DvdId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar la {0}")]
        [Index("IX_Dvd_GeneroId_CategoriaId_TipoDvdId_Titulo", Order = 2, IsUnique = true)]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Index("IX_Dvd_GeneroId_CategoriaId_TipoDvdId_Titulo", Order = 3, IsUnique = true)]
        [Display(Name = "Tipo de Dvd")]
        public int TipoDvdId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Index("IX_Dvd_GeneroId_CategoriaId_TipoDvdId_Titulo", Order = 1, IsUnique = true)]
        [Display(Name = "Género")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Dvd_Titulo", Order = 2, IsUnique = true)]
        [Index("IX_Dvd_GeneroId_CategoriaId_TipoDvdId_Titulo", Order = 4, IsUnique = true)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int AñoGrabacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Duracion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe estar entre {1} y {2}")]
        [Display(Name = "Precio Costo")]
        public decimal PrecioCosto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe estar entre {1} y {2}")]
        [Display(Name = "Precio Venta")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el {0}")]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual TipoDvd TipoDvd { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Producto Producto { get; set; }

       
    }
}