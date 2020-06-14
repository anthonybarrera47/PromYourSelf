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
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
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
