﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Etiquetas : CamposEstandar
    {
        [Key]
        public int ID{ get; set; }
        public string  Nombre{ get; set; }
    }
}
