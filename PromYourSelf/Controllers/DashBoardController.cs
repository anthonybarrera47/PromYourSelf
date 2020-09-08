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
using PromYourSelf.ViewModels;

namespace PromYourSelf.Controllers
{
    [Authorize]
    public class DashBoardController : BaseController
    {
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly UserManager<Usuarios> _userManager;
        private readonly IRepoWrapper _repo;
        private readonly IHttpContextAccessor _accesor;
        public DashBoardController(SignInManager<Usuarios> signInManager,
           UserManager<Usuarios> userManager, IRepoWrapper repoWrappers, IHttpContextAccessor accessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _repo = repoWrappers;
            _accesor = accessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
		[Authorize]
		public async Task<ActionResult> DashBoard()
        {
			if (User.GetPosicion() != Posicion.Administrador.ToString("G"))
				return RedirectToAction("index", "negocios");

			decimal totalVentas = (await _repo.Ventas.GetListAsync(x => x.EsNulo == false && x.NegocioID == User.GetEmpresaID().ToInt())).Sum(x => x.Monto);
			decimal totalPagos = (await _repo.Pagos.GetListAsync(x => x.EsNulo == false && x.NegocioID == User.GetEmpresaID().ToInt())).Sum(x => x.Monto);
			List<Citas> citas = await _repo.Citas.GetListAsync(x => x.EsNulo == false && x.NegocioID == User.GetEmpresaID().ToInt());
			int totalCitas = citas.Where(x => x.Estado != EstadoCita.Cancelada && x.Estado != EstadoCita.Solicitado).Count();
			int totalCitasPendientes = citas.Where(x => x.Estado == EstadoCita.Solicitado).Count();
			DashboardViewModel dvm = new DashboardViewModel()
			{
				TotalVentas = totalVentas,
				TotalPagos = totalPagos,
				TotalCitas = totalCitas,
				TotalCitasPendientes = totalCitasPendientes
			};
			return View(dvm);
		}
        [Authorize]
        public async Task<IActionResult> DashBoardEmpresarial()
		{
			decimal totalVentas = (await _repo.Ventas.GetListAsync(x => x.EsNulo == false && x.NegocioID == User.GetEmpresaID().ToInt())).Sum(x => x.Monto);
			decimal totalPagos = (await _repo.Pagos.GetListAsync(x => x.EsNulo == false && x.NegocioID == User.GetEmpresaID().ToInt())).Sum(x => x.Monto);
			int totalCitas = (await _repo.Citas.GetListAsync(x => x.EsNulo == false && x.NegocioID == User.GetEmpresaID().ToInt())).Count();
			DashboardViewModel dvm = new DashboardViewModel()
			{
				TotalVentas = totalVentas,
				TotalPagos = totalPagos,
				TotalCitas = totalCitas
			};
			return View(dvm);
		}
	}
}
