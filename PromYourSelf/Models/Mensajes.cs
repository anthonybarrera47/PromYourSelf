﻿using System;
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
        public Usuarios Cliente{ get; set; }
        public int NegocioID { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255,
            ErrorMessage = "El Contenido debe ser menor a 255 caracteres.")]
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