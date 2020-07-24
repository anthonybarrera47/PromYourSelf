using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using PromYourSelf.BLL;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.ViewModels;

namespace PromYourSelf.Controllers
{
    public class EntradaAppController : Controller
    {
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly UserManager<Usuarios> _userManager;
        private readonly IRepoWrapper _repoWrappers;
        public EntradaAppController(SignInManager<Usuarios> signInManager,
           UserManager<Usuarios> userManager, IRepoWrapper repoWrappers)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _repoWrappers = repoWrappers;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Usuario,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("DashBoard", "DashBoard"); // la página donde debe ir después de verificar al usuario.
                    }
                }
            }
            ModelState.AddModelError("", "Usuario/Contraseña Inválidos");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = "")
        {
            var model = new RegisterViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                 //TODO: Agregar posicion como va.
                Usuarios usuarios = RepositorioUsuario.UserViewModelToUser(model);
                usuarios.Posicion = "Administrador";
                var _user = await _userManager.FindByNameAsync(usuarios.UserName);

                if (_user == null)
                {
                    var result = await _userManager.CreateAsync(usuarios, usuarios.Password);

                    if (result.Succeeded)
                    {
                      return RedirectToAction("DashBoard", "DashBoard"); // la página donde debe ir después de verificar al usuario.
                    }
                }

            }
            ModelState.AddModelError("", "Usuario/Contraseña Inválidos");
            return View(model);
        }
        // POST: /api/auth/logout
        [Authorize, HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}
