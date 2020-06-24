using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Citas : CamposEstandar
    {
        [Key]
        public int CitaID { get; set; }
        public Usuarios Cliente { get; set; }
        public int NegocioID { get; set; }
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15,
            ErrorMessage = "Máximo 65 caracteres.")]
        [Display(Name = "Codigo Comprobación")]
        public string CodigoComprobacion { get; set; }
        public EstadoCita Estado { get; set; } 
        public virtual ICollection<CitasDetalle> Details { get; set; }
       
    }
}
