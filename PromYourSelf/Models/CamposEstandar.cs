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
        public int UsuarioID { get; set; }
        public bool EsNulo { get; set; }
        public int CreadoPor { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        public int ModificadoPor { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }
    }
}
