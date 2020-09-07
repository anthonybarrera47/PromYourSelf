using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.Configuraciones;
using PromYourSelf.Models.SweetAlert;
using PromYourSelf.Utils;
using PromYourSelf.ViewModels;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly Contexto db;
        private readonly UserManager<Usuarios> _userManager;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly IRepoWrapper _Repo;
        private readonly ILogger<UsuariosController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly string webRoot;
        public static List<Usuarios> Lista;
        public UsuariosController(Contexto context, IRepoWrapper RepoUsuario,
            SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager,
            IHostingEnvironment env,
            ILogger<UsuariosController> logger, IOptions<AppSettings> AppSettings)
        {
            db = context;
            _Repo = RepoUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
            webRoot = env.WebRootPath;
            _logger = logger;
            _appSettings = AppSettings;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "UserName")
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Usuarios.GetListAsync(x => x.UserName.ToUpper().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Usuarios.GetListAsync(x => true);

            var model = PagingList.Create(Lista, 7, page, sortExpression, "UserName");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _Repo.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Usuarios.SaveAsync(usuarios);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _Repo.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repo.Usuarios.ModifiedAsync(usuarios);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _Repo.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("DashBoard", "DashBoard");
            }

            var usuarios = await _Repo.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            var ViewModel = new ProfileViewModel();
            ViewModel.Nombres = usuarios.Nombres;
            ViewModel.Apellidos = usuarios.Apellidos;
            ViewModel.Email = usuarios.Email;
            ViewModel.Genero = usuarios.Genero;
            ViewModel.Id = usuarios.Id;
            ViewModel.Foto = usuarios.Foto;
            ViewModel.UserName = usuarios.UserName;
            ViewModel.Confirmado = usuarios.Confirmado;
            return View(ViewModel);
        }
        //TODO: Perfil Usuario : 3 - Crear un método post en el UsuarioController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile([Bind("Id, Nombres,Apellidos,Genero,UserName, Email, Foto,Confirmado")] ProfileViewModel modelo, IFormFile logo, bool removeLogo)
        {
            //Valida que si se cambia el correo no exista otro usuario con el mismo asignado.
            var u = await _Repo.Usuarios.GetUserInfoById(modelo.Id); //No se puede registrar el mismo correo en el sistema dos veces
            if (u != null && u.Id != modelo.Id)
                ModelState.AddModelError("", $"El correo {modelo.Email} ya está registrado.");

            if (!u.Email.IsValidEmail()) //Esta es una extension que valida el email valido o invalido.
                ModelState.AddModelError("", $"El Email {modelo.Email} no es correcto.");

            ModelState.Remove("Apellidos");
            ModelState.Remove("Telefono");
            ModelState.Remove("Nombres");
            ModelState.Remove("Apellidos");
            ModelState.Remove("removeLogo");

            if (ModelState.IsValid)
            {
                var user = await _Repo.Usuarios.FindAsync(modelo.Id);

                if (user != null)
                {
                    if (removeLogo || logo != null)
                    {
                        if (user.Foto != null)
                        {
                            string archivoActual = Path.Combine(webRoot, _appSettings.Value.RutaImagenesUsers, user.Foto);
                            if (System.IO.File.Exists(archivoActual))
                            {
                                try
                                {
                                    System.GC.Collect(); ///Si no se hace esto dice algunas veces quel archivo esta siendo utilizado por otro proceso
                                    System.GC.WaitForPendingFinalizers();
                                    System.IO.File.Delete(archivoActual);

                                }
                                catch (Exception e)
                                {
                                    _logger.LogDebug("PerfilUsuario", e);
                                }
                            }
                        }
                        user.Foto = null;
                    }
                    if (logo != null && !removeLogo)
                    {
                        string fileExtension = Path.GetExtension(logo.FileName);
                        string fileName = user.Id + fileExtension;
                        user.Foto = fileName;
                        fileName = Path.Combine(webRoot, _appSettings.Value.RutaImagenesUsers, fileName);
                        logo.CopyTo(new FileStream(fileName, FileMode.Create));
                        //user.Foto = await Utils.Utils.ImageToBase64(logo);
                    }
                    user.Nombres = modelo.Nombres;
                    user.Apellidos = modelo.Apellidos;
                    user.PhoneNumber = modelo.Telefono;
                    user.ModificadoPor = User.GetUserID().ToInt();
                    user.FechaModificacion = DateTime.Now;
                    modelo.Foto = user.Foto;
                }


                var result = await _userManager.UpdateAsync(user); //actualiza el usuario
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    await _Repo.Usuarios.UpdateClaimsUser(_signInManager, _userManager, user);
                    return RedirectToAction("Profile", "Usuarios");
                }

            }
            return View(modelo);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Usuarios.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        private bool UsuariosExists(int id)
        {
            return _Repo.Usuarios.Exists(id);
        }
        public async Task<ActionResult> ChangePassword()
        {
            var user = await _userManager.FindByIdAsync(this.User.GetUserID());
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            if (user != null)
            {
                model.Nombre = user.Nombres;
                model.UserID = this.User.GetUserID().ToInt();
            }
            return View(model);
        }

        //TODO: Cambiar Password: 2 - Agregar el método CambiarPassword GET y POST en el Controller y luego el View

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind("UserID, PasswordActual, Password, ConfirmarPassword")] ChangePasswordViewModel modelo)
        {

            var user = await _userManager.FindByIdAsync(this.User.GetUserID());
            var checkPassResult = await _userManager.CheckPasswordAsync(user, RepositorioUsuario.SHA1(modelo.PasswordActual));
            if (!checkPassResult)
            {
                ModelState.AddModelError("", "Contraseña actual incorrecta.");
            }

            if (!RepositorioUsuario.SHA1(modelo.Password).Equals(RepositorioUsuario.SHA1(modelo.ConfirmarPassword)))
            {
                ModelState.AddModelError("", "Las contraseñas con coinciden.");
            }

            if (ModelState.IsValid)
            {
                //TODO: Cambiar Password: 2 - Validar el modelo , usar el userManager para resetear el password en el POST de CambiarPassword
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, RepositorioUsuario.SHA1(modelo.Password));
                if (result.Succeeded)
                {
                    SweetAlert(TitleType.OperacionExitosa, MessageType.RegistroGuardado, IconType.success);
                    return RedirectToAction("Profile", new RouteValueDictionary(
                                                                    new { controller = "Usuarios", action = "Profile", Id = modelo.UserID }));
                }
                else
                    ModelState.AddModelError("", result.Errors.FirstOrDefault().ToString());
            }

            return View(modelo);
        }
        public async Task<ActionResult> ConfirmarUsuario(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("DashBoard", "DashBoard");
            }

            var usuarios = await _Repo.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            else
            {
                await EntradaAppController.SendMail(usuarios, _Repo);
            }

            var ViewModel = new ConfirmarUsuarioViewModel();
            ViewModel.UsuarioID = usuarios.Id;
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmarUsuario([Bind("CodigoConfirmacion")] ConfirmarUsuarioViewModel modelo)
        {
            CodeValidation Code = await _Repo.CodeValidation.FindAsync(x => x.Codigo.Equals(modelo.CodigoConfirmacion));
            Usuarios Usuarios = await _Repo.Usuarios.FindAsync(User.GetUserID().ToInt());
            string Codigo = modelo.CodigoConfirmacion;

            if (Code.UsuarioID.Equals(User.GetUserID().ToInt()))
            {
                if (Code.Codigo.Equals(Codigo))
                {
                    double x = (Code.TiempoExpiracion - DateTime.Now).TotalMilliseconds;

                    if (x < 0)
                    {
                        await EntradaAppController.SendMail(Usuarios, _Repo);
                        SweetAlert(TitleType.OperacionFallida, MessageType.CodigoExpirado, IconType.warning);
                        return View(modelo);
                    }
                    else
                    {
                        Usuarios.Confirmado = true;
                        if (await _Repo.Usuarios.ModifiedAsync(Usuarios))
                            SweetAlert(TitleType.OperacionExitosa, MessageType.UsuarioConfirmado, IconType.success);
                        else
                            SweetAlert(TitleType.OperacionFallida, MessageType.UsuarioNoConfirmado, IconType.error);

                        return RedirectToAction("Profile", "Usuarios", new { id = Usuarios.Id });
                    }
                }
            }


            return View();
        }
        public async Task<ActionResult> ResetPassword()
        {
            var user = await _userManager.FindByIdAsync(this.User.GetUserID());
            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                UserID = this.User.GetUserID().ToInt()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword([Bind("UserID, Password, ConfirmarPassword")] ResetPasswordViewModel modelo)
        {
            var user = await _userManager.FindByIdAsync(this.User.GetUserID());

            if (!modelo.Password.Equals(modelo.ConfirmarPassword))
                ModelState.AddModelError("", "Las contraseñas con coinciden.");

            if (ModelState.IsValid)
            {
                //TODO: Cambiar Password: 2 - Validar el modelo , usar el userManager para resetear el password en el POST de CambiarPassword
                user.PasswordRecovery = string.Empty;
                user.TimeExpired = DateTime.MinValue;
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, modelo.Password);
                if (result.Succeeded)
                {
                    SweetAlert(TitleType.OperacionExitosa, MessageType.RegistroGuardado, IconType.success);
                    return RedirectToAction("Profile", new RouteValueDictionary(
                                                                    new { controller = "Usuarios", action = "Profile", Id = modelo.UserID }));
                }
                else
                    ModelState.AddModelError("", result.Errors.FirstOrDefault().ToString());
            }

            return View(modelo);
        }
    }
}
