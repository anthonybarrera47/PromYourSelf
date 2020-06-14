using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Usuarios;

namespace Entidades
{
    public class Empleados : CamposEstandar
    {
        [Key]
        public int EmpleadoID { get; set; }
        public Negocios Negocio{ get; set; }
        public string Foto{ get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(10, ErrorMessage = "Cantidad máxima de caracteres 10.")]
        public string Nombre{ get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellido{ get; set; }
        public TipoGenero Genero{ get; set; }
        public bool Estado { get; set; }
        public virtual List<Productos> Productos { get; set; }
    }
}
