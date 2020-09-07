using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models
{
	[NotMapped]
	public class UsuariosMensaje
	{
		[Key]
		public int Id { get; set; }
		public string Contenido { get; set; }
		public int UsuarioID { get; set; }
		public int ReceptorID { get; set; }
		public string Nombre { get; set; }
		public string Posicion { get; set; }
		public int MensajeID { get; set; }
	}
}
