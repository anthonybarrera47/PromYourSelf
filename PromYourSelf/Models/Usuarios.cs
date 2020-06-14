using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios : CamposEstandar
    {
        [Key]
        public int UsuarioID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellidos { get; set; }
        public string Foto { get; set; }
        public TipoGenero Genero { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Column("Email", TypeName = "varchar(50)")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public bool Confirmado { get; set; }
        [Display(Name = "Tipo Usuario")]
        public TiposUsuario TipoUsuario { get; set; }
        public bool Estado { get; set; }

        public enum TipoGenero
        {
            Masculino = 0,
            Femenino = 1,
            Otros = 2
        }
        public enum TiposUsuario
        {
            Cliente = 0,
            Administrador = 1
        }
    }
}
