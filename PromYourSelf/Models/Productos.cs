﻿using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Productos : CamposEstandar
    {
        [Key]
        public int ProductoID { get; set; }
        public int NegocioID { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        public string Nombre { get; set; }
        [StringLength(255,
            ErrorMessage = "La descripción no debe de tener mas de 255 caracteres.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Unidad { get; set; }
        [Required(ErrorMessage = "Ingrese un stock.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Precio Oferta")]
        public decimal PrecioOferta { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Tipo Productos")]
        public TipoProducto TipoProductos { get; set; }
        public virtual List<EtiquetasDetails> Etiquetas { get; set; }
        public virtual List<FotosProductos> Fotos { get; set; }

    }
}
