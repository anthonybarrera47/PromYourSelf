using Models;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Pagos : CamposEstandar
    {
        [Key]
        public int PagoID { get; set; }
        public DateTime Fecha { get; set; }
        public int NegocioID { get; set; }
        public decimal Monto { get; set; }
        public TipoClasificacion TipoClasificacion { get; set; }
        public string Concepto { get; set; }
        public Pagos()
        {
            PagoID = 0;
            Fecha = DateTime.Now;
            NegocioID = 0;
            Monto = 0;
            TipoClasificacion = null;
            Concepto = string.Empty;
        }
        public Pagos(int pagoID, int negocioID, decimal monto, TipoClasificacion tipoClasificacion, string concepto)
        {
            PagoID = pagoID;
            NegocioID = negocioID;
            Monto = monto;
            TipoClasificacion = tipoClasificacion ?? throw new ArgumentNullException(nameof(tipoClasificacion));
            Concepto = concepto ?? throw new ArgumentNullException(nameof(concepto));
        }
    }
}
