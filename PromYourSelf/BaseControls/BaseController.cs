using Microsoft.AspNetCore.Mvc;
using PromYourSelf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models.SweetAlert
{
    public abstract class BaseController : Controller
    {
        public void SweetAlert(TitleType Title, MessageType Mensaje, IconType Icon)
        {
            var HTML = "Swal.fire({title: '" + Title.GetDescription() + "', text: '" + Mensaje.GetDescription() + "',type: '" + Icon + "' });";
            TempData["SweetAlert"] = HTML;
        }
        public void ToastSweetAlert(IconType Icon, MessageType Mensaje)
        {
            var HTML = "const Toast = Swal.mixin({toast: true, position: 'top-end', showConfirmButton: false, timer: 3000});Toast.fire({type: '" + Icon.GetDescription() + "',title: '" + Mensaje.GetDescription() + "'});";
            TempData["ToastSweetAlert"] = HTML;
        }
    }
}
