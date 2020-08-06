using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromYourSelf.Models.SweetAlert;

namespace PromYourSelf.Controllers
{
   
    public class DashBoardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            return View();
        }

		public IActionResult DashBoardEmpresarial()
		{
			return View();
		}
	}
}
