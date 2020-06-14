using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos : CamposEstandar
    {
        [Key]
        public int ProductoID { get; set; }
        public Negocios Negocios{ get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Unidad { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioOferta { get; set; }
        public TipoProducto TipoProductos { get; set; }
        public virtual List<Etiquetas> Etiquetas { get; set; }
        public virtual List<FotosProductos> Fotos { get; set; }

        public enum TipoProducto
        {
            Producto = 0,
            Servicio =1 
        }
    }
}
