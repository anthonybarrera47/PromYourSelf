using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromYourSelf.Models.SweetAlert;

namespace PromYourSelf.Controllers
{
    [Authorize]
    public class DashBoardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult DashBoard()
        {
            return View();
        }
        [Authorize]
        public IActionResult DashBoardEmpresarial()
		{
			return View();
		}
	}
}
