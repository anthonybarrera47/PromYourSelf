using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.SweetAlert;
using PromYourSelf.Utils;

namespace PromYourSelf.Controllers
{
    [Authorize]
    public class DashBoardController : BaseController
    {
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly UserManager<Usuarios> _userManager;
        private readonly IRepoWrapper _repoWrappers;
        private readonly IHttpContextAccessor _accesor;
        public DashBoardController(SignInManager<Usuarios> signInManager,
           UserManager<Usuarios> userManager, IRepoWrapper repoWrappers, IHttpContextAccessor accessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _repoWrappers = repoWrappers;
            _accesor = accessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult DashBoard()
        {
            var user =_accesor.HttpContext.User;
            return View();
        }
        [Authorize]
        public IActionResult DashBoardEmpresarial()
		{
			return View();
		}
	}
}
