using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
    public class ResetPasswordViewModel
    {
		[Required]
		[Display(Name = "ID")]
		public int UserID { get; set; }

		[Required(ErrorMessage = "La Contraseña no puede estar en blanco.")]
		[MaxLength(30, ErrorMessage = "La cantidad máxima es de 30 caracteres.")]
		[Display(Name = "Nueva Contraseña")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "La Confirmación de la Contraseña no puede estar en blanco.")]
		[Display(Name = "Confirmar Nueva Contraseña")]
		[MaxLength(30, ErrorMessage = "La cantidad máxima es de 30 caracteres.")]

		[Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
		[DataType(DataType.Password)]
		public string ConfirmarPassword { get; set; }
	}
}
