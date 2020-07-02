using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FotosProductos
    {
        [Key]
        public int FotoID { get; set; }
        public Productos Productos{ get; set; }
        public string Foto { get; set; }

    }
}
