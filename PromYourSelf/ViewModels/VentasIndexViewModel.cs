using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
    public class VentasIndexViewModel : CamposEstandar
    {
        public int VentaID { get; set; }
        public int UsuarioClienteID { get; set; }
        public int NegocioID { get; set; }
        public string Nombres { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int CitaID { get; set; }
        public virtual List<VentasDetalle> Details { get; set; }

        public VentasIndexViewModel()
        {
            VentaID = 0;
            NegocioID = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            CitaID = 0;
            Details = new List<VentasDetalle>();
        }
    }
}
