using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class TipoProducto
    {
        [Key]
        public int TipoProductoId { get; set; }

        public string Tipo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}