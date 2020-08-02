using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
    public class ProfileViewModel
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Digite el nombre completo.")]
		[MaxLength(50)]
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public TipoGenero Genero { get; set; }
		[Display(Description ="Nombre de usuario")]
		public string UserName { get; set; }
		public string Foto { get; set; }
		[NotMapped]
		public IFormFile FotoFile { get; set; }

		[MaxLength(256)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Teléfono")]
		public string Telefono { get; set; }
		public bool Confirmado { get; set; }
	}
}
