using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.ControlUsers;
using PromYourSelf.Models.SweetAlert;

namespace PromYourSelf.Controllers
{
    public class RolesController : BaseController
    {
        private readonly Contexto _context;
        private readonly RoleManager<Roles> _roleManager;
        private readonly IRepoWrapper _repo;
        private readonly IOptions<ErrorMsg> _ErrorMsg;
        public RolesController(IRepoWrapper repo, Contexto context, RoleManager<Roles> roleManager
            , IOptions<ErrorMsg> appErrorMsg)
        {
            _context = context;
            _roleManager = roleManager;
            _repo = repo;
            _ErrorMsg = appErrorMsg;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _repo.Rol.GetListAsync(x=>true));
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _repo.Rol.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Roles applicationRole)
        {

            if (ModelState.IsValid)
            {
                var error = await _repo.Rol.CrearRolAsync(applicationRole);
                if (error.OK)
                {
                    return RedirectToAction(nameof(Index));
                }
                if (!error.OK)
                {
                    ModelState.AddModelError("Error", error.Descripcion);
                }
            }
            return View(applicationRole);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRole = await _repo.Rol.FindAsync(id);
            if (applicationRole == null)
            {
                return NotFound();
            }

            return View(applicationRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationRole = await _repo.Rol.FindAsync(id);
            //await _rolRepo.Eliminar(applicationRole);
            await _roleManager.DeleteAsync(applicationRole);
            return RedirectToAction(nameof(Index));
        }

    }
}
