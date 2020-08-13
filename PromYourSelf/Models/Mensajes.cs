using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Mensajes : CamposEstandar
    {
        [Key]
        public int MensajeID { get; set; }
		public int ReceptorID { get; set; }
		[ForeignKey("ReceptorID")]
		public Usuarios Receptor { get; set; }		
		[Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255,
            ErrorMessage = "El Contenido debe ser menor a 255 caracteres.")]
        public string Contenido { get; set; }
        public TipoContenido Tipo { get; set; }
        //TODO: IMAGEN PA LA PROXIMAAAAA
        public EstadoMensaje EstadoMensaje { get; set; }

    }
}
