using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models
{
	public class EtiquetasDetails 
	{	
		[Key]
		public int ID { get; set; }
		public int ProductoID { get; set; }
		public int EtiquetaID { get; set; }
		[ForeignKey("EtiquetaID")]
		public Etiquetas Etiqueta { get; set; }
	}
}
