using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mensajes : CamposEstandar
    {
        [Key]
        public int MensajeID { get; set; }
        public Usuarios Cliente{ get; set; }
        public Negocios Negocios{ get; set; }
        public string Contenido { get; set; }
        public TipoContenido Tipo { get; set; }
        //TODO: IMAGEN PA LA PROXIMAAAAA

        public enum TipoContenido
        {
            Texto = 0,
            Base64 = 1,
            Documento = 2

        }
    }
}
