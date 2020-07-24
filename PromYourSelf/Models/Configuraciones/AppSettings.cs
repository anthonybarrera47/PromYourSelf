using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models.Configuraciones
{
    public class AppSettings
    {
		public string Version { get; set; }
		public string Nombre { get; set; }
		public string Idioma { get; set; }
		public string EnProduccion { get; set; }
		public string NombreAbreviado { get; set; }
		public string RutaImagenesOrgs { get; set; }
		public string RutaImagenesUsers { get; set; }
		public string UserSinFoto { set; get; }
		public string UrlFotosUsuario { get; set; }

		public string ImagenNoDisponible { get; set; }
		public string UrlImagenesOrg { get; set; }

		public string UrlImagenesCarrousel { get; set; }
	}
}
