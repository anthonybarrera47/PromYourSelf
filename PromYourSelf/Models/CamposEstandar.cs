using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class CamposEstandar
    {
        public int CreadoPor { get; set; }
        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FechaCreacion { get; set; }
        public int ModificadoPor { get; set; }
        [Display(Name = "Fecha Modificacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FechaModificacion { get; set; }
    }
}
