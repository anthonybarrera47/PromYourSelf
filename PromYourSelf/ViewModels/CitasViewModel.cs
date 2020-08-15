using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
	public class CitasViewModel
	{
		public Productos Producto { get; set; }
		public Citas Cita { get; set; }

		public Negocios Negocio { get; set; }

		public CitasViewModel(Productos producto, Negocios negocio, Citas cita)
		{
			this.Producto = producto;
			this.Cita = cita;
			this.Negocio = negocio;
		}
		public CitasViewModel()
		{

		}

	}
}
