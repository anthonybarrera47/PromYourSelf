using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class CitasDetalle
    {
        [Key]
        public int ID { get; set; }
        public Citas Cita{ get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
