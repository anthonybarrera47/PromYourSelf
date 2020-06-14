using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Negocios : CamposEstandar
    {
        [Key]
        public int NegocioID { get; set; }
        public Usuarios Usuario{ get; set; }
        public Horarios Horarios{ get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public Ciudad Ciudad { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

    }
}
