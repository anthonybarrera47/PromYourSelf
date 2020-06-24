using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Usuarios;

namespace Models
{
    public class Empleados : CamposEstandar
    {
        [Key]
        public int EmpleadoID { get; set; }
        public int NegocioID { get; set; }
        public byte[] Foto { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Cantidad máxima de caracteres 50.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellido { get; set; }
        public TipoGenero Genero { get; set; }
        public bool Estado { get; set; }
        public virtual List<Productos> Productos { get; set; }

        public Empleados(int empleadoID, byte[] foto, string nombre, string apellido, TipoGenero genero, bool estado)
        {
            EmpleadoID = empleadoID;
            Foto = foto ?? throw new ArgumentNullException(nameof(foto));
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            Genero = genero;
            Estado = estado;
            Productos = new List<Productos>();
        }

        public Empleados()
        {
            EmpleadoID = 0;
            Foto = null;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Genero = TipoGenero.Masculino;
            Estado = false;
            Productos = new List<Productos>();
        }
    }
}
