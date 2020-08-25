using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VentasDetalle
    {
        [Key]
        public int ID { get; set; }
        public Ventas Venta { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int ProductoID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
		[ForeignKey("ProductoID")]
		public Productos Producto { get; set; }

	}
}
