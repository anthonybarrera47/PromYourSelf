using Microsoft.AspNetCore.Identity;
using PromYourSelf.Models.ControlUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuarios : IdentityUser<int>
    {
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
        public override string Email { get; set; }
        public bool Confirmado { get; set; }
        [Display(Name = "Tipo Usuario")]
        public TiposUsuario TipoUsuario { get; set; }
        [StringLength(40)]
        [Required]
        public string Posicion { get; set; }
        public bool Estado { get; set; }
        public bool EsNulo { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public Usuarios(string password, string nombres, string apellidos, string foto, TipoGenero genero, string email, bool confirmado, TiposUsuario tipoUsuario, string posicion, bool estado, bool esNulo, int creadoPor, DateTime fechaCreacion, int modificadoPor, DateTime fechaModificacion, ICollection<UserRole> userRoles)
        {
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Foto = foto ?? throw new ArgumentNullException(nameof(foto));
            Genero = genero;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Confirmado = confirmado;
            TipoUsuario = tipoUsuario;
            Posicion = posicion ?? throw new ArgumentNullException(nameof(posicion));
            Estado = estado;
            EsNulo = esNulo;
            CreadoPor = creadoPor;
            FechaCreacion = fechaCreacion;
            ModificadoPor = modificadoPor;
            FechaModificacion = fechaModificacion;
            UserRoles = userRoles ?? throw new ArgumentNullException(nameof(userRoles));
        }

        public Usuarios()
        {
            Password = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Foto = string.Empty;
            Genero = TipoGenero.Masculino;
            Email = string.Empty;
            Confirmado = false;
            TipoUsuario = TiposUsuario.Guest;
            Posicion = string.Empty;
            Estado = false;
            EsNulo = false;
            CreadoPor = 0;
            FechaCreacion = DateTime.Now;
            ModificadoPor = 0;
            FechaModificacion = DateTime.Now;
            UserRoles = new List<UserRole>();
        }
    }
}
