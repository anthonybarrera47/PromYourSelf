using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using PromYourSelf.BLL;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.SweetAlert;
using PromYourSelf.Utils;
using PromYourSelf.ViewModels;

namespace PromYourSelf.Controllers
{
    public class EntradaAppController : BaseController
    {
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly UserManager<Usuarios> _userManager;
        private readonly IRepoWrapper _repoWrappers;
        private readonly IHttpContextAccessor _accesor;
        public EntradaAppController(SignInManager<Usuarios> signInManager,
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
        public bool VerifiedPasswordRecovery(Usuarios user, string Password)
        {
            bool Paso = false;
            double Time = (user.TimeExpired - DateTime.Now).TotalMilliseconds;
            if (user.PasswordRecovery != null && user.PasswordRecovery.Length > 0)
                if (Time >= 0 || user.PasswordRecovery.Equals(Password))
                    Paso = true;
            return Paso;
        }
        [HttpGet]
        [AllowAnonymous]
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
            try
            {
                Usuarios appUser = await _userManager.FindByNameAsync(model.Usuario);
                bool isTemporalyPassword = false;
                Microsoft.AspNetCore.Identity.SignInResult result = Microsoft.AspNetCore.Identity.SignInResult.Failed;
                string Password = string.Empty;
                if (appUser != null)
                {
                    if (ModelState.IsValid)
                    {
                        await _signInManager.SignOutAsync();
                        var user = await _userManager.FindByNameAsync(model.Usuario);
                        model.Password = RepositorioUsuario.SHA1(model.Password);                        

                        isTemporalyPassword = VerifiedPasswordRecovery(user, model.Password);

                        if (isTemporalyPassword)
                        {
                            await _signInManager.SignInAsync(user,false);
                            SweetAlert(TitleType.Informacion, MessageType.PasswordReset, IconType.info);

                        }
                        else
                            result = await _signInManager.PasswordSignInAsync(model.Usuario,
                                                  model.Password, model.RememberMe, false);

                        if (result.Succeeded || isTemporalyPassword)
                        {
                            await _repoWrappers.Usuarios.UpdateClaimsUser(_signInManager, _userManager, user);

      
                            if (isTemporalyPassword)
                                return RedirectToAction("ResetPassword", "Usuarios", new { user.Id });
                            else if (model.ReturnUrl == null || model.ReturnUrl.Equals("/"))
                                return RedirectToAction("DashBoard", "DashBoard");
                            else if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                                return Redirect(model.ReturnUrl);
                            else
                            {
                                if (user.Posicion == Posicion.Administrador.GetDescription())
                                {
                                    await SaveDefaultCompany(user);
                                    return RedirectToAction("DashBoardEmpresarial", "DashBoard");
                                }
                                else
                                    return RedirectToAction("Index", "Negocios");
                            }
                        }
                        else
                            SweetAlert(TitleType.Informacion, MessageType.CredencialesInvalidas, IconType.error);
                    }
                    else
                        SweetAlert(TitleType.Informacion, MessageType.CredencialesInvalidas, IconType.error);
                }
                else
                    SweetAlert(TitleType.Informacion, MessageType.CredencialesInvalidas, IconType.error);

            }
            catch (Exception)
            {
                throw;
            }
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
                Usuarios usuarios = RepositorioUsuario.UserViewModelToUser(model);
                usuarios.Posicion = Posicion.Normal.GetDescription();
                var _user = await _userManager.FindByNameAsync(usuarios.UserName);
                if (_user == null)
                {
                    var result = await _userManager.CreateAsync(usuarios, usuarios.Password);

                    if (result.Succeeded)
                    {
                        await EntradaAppController.SendMail(usuarios, _repoWrappers);
                        //TODO: LOGIN DIRECTO LUEGO DE REGISTRAR
                        var result2 = await _signInManager.PasswordSignInAsync(usuarios.UserName,
                                                   usuarios.Password, false, false);
                        if (result2.Succeeded)
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
            var Usuarios = await _repoWrappers.Usuarios.FindAsync(User.GetUserID().ToInt());
            await _signInManager.SignOutAsync();
            await _repoWrappers.Usuarios.RemoveClaimsUser(_signInManager, _userManager, Usuarios);
            _accesor.HttpContext.Response.Cookies.Delete(".applicationname");
            return RedirectToAction("Dashboard", "Dashboard");
        }

        public async Task SaveDefaultCompany(Usuarios usuario)
        {

            bool save = (await _repoWrappers.Negocios.GetListAsync(m => m.UsuarioID == usuario.Id)).ToList().Count() <= 0;
            if (save)
            {
                Negocios negocio = new Negocios
                {
                    UsuarioID = usuario.Id,
                    Telefono1 = "809231231",
                    Telefono2 = "809231231",
                    Direccion = "SFM",
                    NombreComercial = "PromYourSelfDefault",
                };
                await _repoWrappers.Negocios.SaveAsync(negocio);
            }
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            var Usuario = await _userManager.FindByEmailAsync(Email);

            if (Usuario != null)
            {
                string PassWord = Utils.Utils.GenerarToken();
                Usuario.PasswordRecovery = RepositorioUsuario.SHA1(PassWord);
                Usuario.TimeExpired = DateTime.Now.AddDays(1);

                var result = await _userManager.UpdateAsync(Usuario);
                if (result.Succeeded)
                {
                    await SendMailWithFakePassword(Usuario, PassWord);
                    SweetAlert(TitleType.OperacionExitosa, MessageType.PasswordSend, IconType.success);
                }
                else
                    SweetAlert(TitleType.OperacionFallida, MessageType.PasswordSend, IconType.error);


            }
            else
                SweetAlert(TitleType.OperacionFallida, MessageType.PasswordExpired, IconType.warning);

            return View();
        }
        public static async Task SendMail(Usuarios usuarios, IRepoWrapper _repoWrappers)
        {
            bool Paso = false;
            MailMessage mail = new MailMessage();
            CodeValidation Code = new CodeValidation();
            Code.UsuarioID = usuarios.Id;
            Code.Email = usuarios.Email;
            Code.UsuarioID = usuarios.Id;
            Code.TiempoExpiracion = DateTime.Now.AddDays(1);//24Horas para expirar el codigo.
            Code = _repoWrappers.CodeValidation.GenerarToken(Code);
            CodeValidation CodeModificar = await _repoWrappers.CodeValidation.FindAsync(x => x.UsuarioID.Equals(Code.UsuarioID));

            if (CodeModificar == null)
            {
                Paso = await _repoWrappers.CodeValidation.SaveAsync(Code);
            }
            else
            {
                double x = (Code.TiempoExpiracion - DateTime.Now).TotalMilliseconds;
                if (x < 0)
                {
                    CodeModificar.TiempoExpiracion = DateTime.Now.AddDays(1);
                    CodeModificar = _repoWrappers.CodeValidation.GenerarToken(Code);
                    Paso = await _repoWrappers.CodeValidation.ModifiedAsync(Code);
                }
            }
            if (Paso)
            {
                mail.From = new MailAddress("proyectoaplicada2@gmail.com");
                mail.To.Add(usuarios.Email);
                mail.Subject = "Código de verificacion";
                mail.Body = $"Su codigo es : {Code.Codigo}";
                await Utils.Utils.SendMail(mail);
            }

        }
        public static async Task SendMailWithFakePassword(Usuarios usuarios,string Password)
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("proyectoaplicada2@gmail.com")
            };
            mail.To.Add(usuarios.Email);
            mail.Subject = "Contraseña temporal";
            mail.Body = $"Su Contraseña temporal es : {Password}";
            await Utils.Utils.SendMail(mail);
        }

    }
}
