using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
	public class DashboardViewModel
	{
		public decimal TotalVentas { get; set; }
		public decimal TotalPagos { get; set; }
		public int TotalCitas { get; set; }
		public int TotalCitasPendientes { get; set; }
	}
}
