using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FinalRuiz2018.Models;

namespace FinalRuiz2018.ViewModels
{
    [NotMapped]
    public class UsuarioViewModel:Usuario
    {
        public HttpPostedFileBase ArchivoFoto { get; set; }
    }
}