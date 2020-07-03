using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int NegocioID { get; set; }
        public int EmpleadoAsignado { get; set; }
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15,
            ErrorMessage = "Máximo 65 caracteres.")]
        [Display(Name = "Codigo Comprobación")]
        public string CodigoComprobacion { get; set; }
        public string Notas { get; set; }
        public EstadoCita Estado { get; set; } 
        public virtual ICollection<CitasDetalle> Details { get; set; }

        public Citas()
        {
            CitaID = 0;
            NegocioID = 0;
            EmpleadoAsignado = 0;
            FechaInicio = DateTime.Now;
            FechaFin = DateTime.Now.AddDays(1);
            CodigoComprobacion = string.Empty;
            Notas = string.Empty;
            Estado = EstadoCita.Solicitado;
            Details = new Collection<CitasDetalle>();
        }
    }
}
