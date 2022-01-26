using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FinalRuiz2018.Models;

namespace FinalRuiz2018.ViewModels
{
    [NotMapped]
    public class DvdViewModel:Dvd
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ProductId { get; set; }
    }
}