using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models
{
    public class TipoClasificacion : CamposEstandar
    {
        [Key]
        public int TipoClasificacionID { get; set; }
        public string Descripcion { get; set; }

        public TipoClasificacion()
        {
            TipoClasificacionID = 0;
            Descripcion = string.Empty;
        }

        public TipoClasificacion(int tipoClasificacionID, string descripcion)
        {
            TipoClasificacionID = tipoClasificacionID;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
        }
    }
}
