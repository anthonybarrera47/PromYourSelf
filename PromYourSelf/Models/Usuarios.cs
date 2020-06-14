using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios : CamposEstandar
    {
        [Key]
        public int UsuarioID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Foto { get; set; }
        public TipoGenero Genero { get; set; }
        public string Email { get; set; }
        public bool Confirmado { get; set; }
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
