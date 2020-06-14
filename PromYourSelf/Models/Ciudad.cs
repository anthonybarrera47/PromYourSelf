using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad
    {
        [Key]
        public int CiudadID { get; set; }
        public string City { get; set; }
        public string CityAscii { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Country { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string AdminName { get; set; }
        public string Capital { get; set; }

    }
}
