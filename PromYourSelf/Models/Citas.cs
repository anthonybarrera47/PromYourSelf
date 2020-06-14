using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Citas : CamposEstandar
    {
        [Key]
        public int CitaID { get; set; }
        public Usuarios Cliente { get; set; }
        public Negocios Negocio{ get; set; }

        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15,
            ErrorMessage = "Maximo 65 caracteres.")]
        [Display(Name = "Codigo Comprobacion")]
        public string CodigoComprobacion { get; set; }
        public EstadoCita Estado { get; set; }
        public virtual List<CitasDetalle> Details { get; set; }

        public enum EstadoCita
        {
			Solicitado = 0,
            EnProceso = 1,
            Finalizado = 2
        }

    }
}
