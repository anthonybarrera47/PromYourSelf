using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int ID { get; set; }
        public Ventas Venta { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
