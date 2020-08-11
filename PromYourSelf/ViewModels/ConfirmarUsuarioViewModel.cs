using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
    public class ConfirmarUsuarioViewModel
    {
        public int UsuarioID { get; set; }
        [Display(Name ="Código de confirmación")]
        public string CodigoConfirmacion { get; set; }
    }
}
