using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.Configuraciones;
using PromYourSelf.Utils;
using PromYourSelf.ViewModels;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class UsuariosController : Controller
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
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "UserName", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Usuarios.GetListAsync(x => x.UserName.ToUpper().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Usuarios.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "UserName");
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

            var usuarios = await _Repo.Usuarios.SearchAsync(id);

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

            var usuarios = await _Repo.Usuarios.SearchAsync(id);
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

            var usuarios = await _Repo.Usuarios.SearchAsync(id);
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

            var usuarios = await _Repo.Usuarios.SearchAsync(id);
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
            return View(ViewModel);
        }
        //TODO: Perfil Usuario : 3 - Crear un método post en el UsuarioController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile([Bind("Id, Nombres,Apellidos,Genero,UserName, Email, Foto")] ProfileViewModel modelo, IFormFile logo, string removeLogo)
        {
            //Valida que si se cambia el correo no exista otro usuario con el mismo asignado.
            var u = await _Repo.Usuarios.GetUserInfoByEmail(modelo.Email); //No se puede registrar el mismo correo en el sistema dos veces
            if (u != null && u.Id != modelo.Id)
                ModelState.AddModelError("", $"El correo {modelo.Email} ya está registrado.");

            if (!modelo.Email.IsValidEmail()) //Esta es una extension que valida el email valido o invalido.
                ModelState.AddModelError("", $"El Email {modelo.Email} no es correcto.");

            ModelState.Remove("Apellidos");
            ModelState.Remove("Telefono");
            ModelState.Remove("Nombres");
            ModelState.Remove("Apellidos");

            if (ModelState.IsValid)
            {
                var user = await _Repo.Usuarios.SearchAsync(modelo.Id);

                if (user != null)
                {
                    if (removeLogo.Equals("1") || logo != null)
                    {
                        user.Foto = null;
                    }
                    if (logo != null && removeLogo.Equals("0"))
                    {
                        user.Foto = await Utils.Utils.ImageToBase64(logo);
                    }
                    user.Nombres = modelo.Nombres;
                    user.Email = modelo.Email;
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
                    ///Si todo esta bien colocamos la foto en el claim
                    var userClaims = await _userManager.GetClaimsAsync(user); //busca todos los claims del usuario modificado

                    ///elimina los claims nombre y posicion, el idOrganizacion no cambia
                    await _userManager.RemoveClaimsAsync(user, userClaims.Where(x => x.Type.Equals("Foto")));
                    await _userManager.RemoveClaimsAsync(user, userClaims.Where(x => x.Type.Equals("Nombres")));

                    ///agrega los claims nuevamente
                    await _userManager.AddClaimAsync(user, new Claim("Nombres", user.Nombres));
                    if (user.Foto != null && user.Foto != string.Empty && user.Foto.Length > 0)
                        await _userManager.AddClaimAsync(user, new Claim("Foto", user.Foto));

                    await _signInManager.RefreshSignInAsync(user);
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
    }
}
