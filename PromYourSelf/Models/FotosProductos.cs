using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FotosProductos
    {
        [Key]
        public int FotoId { get; set; }
        public Productos Productos{ get; set; }
        public string Foto { get; set; }

    }
}
