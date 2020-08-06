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
            var HTML = "Swal.fire({title: '"+Title+"', text: '"+Mensaje.GetDescription()+"',type: '"+Icon+"' });";            
            TempData["SweetAlert"] = HTML;
        }
    }
}
