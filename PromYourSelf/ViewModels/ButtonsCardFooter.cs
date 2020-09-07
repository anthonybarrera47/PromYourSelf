using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
    public class ButtonsCardFooter
    {
        public string ActionButtonSaveOrEdit { get; set; } 
        public string TextButtonSaveOrEdit { get; set; }
        public readonly string ActionButtonReset = "Reset";
       
        public readonly string TextButtonReset = "Limpiar";
        public string ActionButtonBackToList { get; set; } = "Index";
        public string TextButtonBackToList { get; set; } = "Volver a la Lista";
        public bool ShowButtonBackToList { get; set; } = true;
        public bool ShowButtonReset { get; set; } = true;
        public string CssButtonSaveOrEdit { get; set; } = "fas fa-save";
    }
}
