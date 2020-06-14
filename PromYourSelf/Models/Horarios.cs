using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horarios
    {
        [Key]
        public int HorarioID { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string viernes { get; set; }
        public string Sabado { get; set; }
        public string Domingo { get; set; }
    }
}
