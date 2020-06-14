using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas : CamposEstandar
    {
        [Key]
        public int VentaID { get; set; }
        public Usuarios Usuarios{ get; set; }
        public Negocios Negocios{ get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int CitaID{ get; set; }
        public virtual List<VentasDetalle> Details{ get; set; }
    }
}
