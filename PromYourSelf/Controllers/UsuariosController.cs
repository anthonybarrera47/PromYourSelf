using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using PromYourSelf.BLL.Interfaces;
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
        private readonly string webRoot;
        public static List<Usuarios> Lista;
        public UsuariosController(Contexto context, IRepoWrapper RepoUsuario,
            SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager,
            IHostingEnvironment env,
            ILogger<UsuariosController> logger)
        {
            db = context;
            _Repo = RepoUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
            webRoot = env.WebRootPath;
            _logger = logger;
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
        public async Task<IActionResult> Create()
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
