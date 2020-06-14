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
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int CitaID{ get; set; }
        public virtual List<VentasDetalle> Details{ get; set; }
    }
}
