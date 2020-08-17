﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
	public class CitasViewModel
	{		
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public String Descripcion { get; set; }
		public string NombreComercial { get; set; }
		public List<Etiquetas> Etiquetas { get; set; }		
		public int NegocioID { get; set; }
		public int EmpleadoAsignado { get; set; }	
		public DateTime FechaInicio { get; set; }	
		public string CodigoComprobacion { get; set; }
		public string Notas { get; set; }
		public EstadoCita Estado { get; set; }
		public int ProductoID { get; set; }
		public int CitaID { get; set; }


		public CitasViewModel(string nombre, decimal precio, string descripcion, List<Etiquetas> etiquetas, string nombre_comercial, int negocioId, int productoId)
		{
			this.Nombre = nombre;
			this.Precio = precio;
			this.Descripcion = descripcion;
			this.NombreComercial = nombre_comercial;			
			this.NegocioID = negocioId;
			this.FechaInicio = new DateTime();
			this.CodigoComprobacion = "";
			this.Notas = "";
			this.ProductoID = productoId;			

					
		}
		public CitasViewModel()
		{

		}

	}
}