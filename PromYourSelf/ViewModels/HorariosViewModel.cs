using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Validaciones;

namespace PromYourSelf.ViewModels
{

    public class HorariosViewModel
    {
        public const string CERRADO = "Cerrado";
        public const string LUNES = "Lunes";
        public const string MARTES = "Martes";
        public const string MIERCOLES = "Miércoles";
        public const string JUEVES = "Jueves";
        public const string VIERNES = "Viernes";
        public const string SABADO = "Sábado";
        public const string DOMINGO = "Domingo";
        public int Id { get; set; }
        public int NegocioId { get; set; }
        [HorasRequiredAttribute("LunesHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string LunesDesde { get; set; }
        public string LunesHasta { get; set; }
        private string LunesHorario
        {
            get
            {
                string Cadena = (LunesDesde + LunesHasta).ToString();
                Cadena = (Cadena == string.Empty ? $"{LUNES} {CERRADO}" : $"{LUNES} {LunesDesde}-{LunesHasta}");
                return Cadena;
            }
            set
            { LunesHorario = value; }
        }
        [HorasRequiredAttribute("MartesHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string MartesDesde { get; set; }
        public string MartesHasta { get; set; }
        private string MartesHorario
        {
            get
            {
                string Cadena = (MartesDesde + MartesHasta).ToString();
                Cadena = (Cadena == string.Empty ? $"{MARTES} {CERRADO}" : $"{MARTES} {MartesDesde }-{MartesHasta}");
                return Cadena;
            }
            set
            { MartesHorario = value; }
        }
        [HorasRequiredAttribute("MiercolesHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string MiercolesDesde { get; set; }
        public string MiercolesHasta { get; set; }
        private string MiercolesHorario
        {
            get
            {
                string Cadena = (JuevesDesde + JuevesHasta).ToString();
                Cadena = (Cadena == string.Empty ? $"{MIERCOLES} {CERRADO}" : $"{MIERCOLES} {MiercolesDesde}-{MiercolesHasta}");
                return Cadena;
            }
            set
            { MiercolesHorario = value; }
        }
        [HorasRequiredAttribute("JuevesHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string JuevesDesde { get; set; }
        public string JuevesHasta { get; set; }
        private string JuevesHorario
        {
            get
            {
                string Cadena = (JuevesDesde + JuevesHasta).ToString();
                Cadena = (Cadena == string.Empty ? $"{JUEVES} {CERRADO}" : $"{JUEVES} {JuevesDesde}-{JuevesHasta}");
                return Cadena;
            }
            set
            { JuevesHorario = value; }
        }
        [HorasRequiredAttribute("ViernesHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string ViernesDesde { get; set; }
        public string ViernesHasta { get; set; }
        private string ViernesHorario
        {
            get
            {
                string Cadena = (ViernesDesde + ViernesHasta).ToString();
                Cadena = (Cadena == string.Empty ? $"{VIERNES} {CERRADO}" : $"{VIERNES} {ViernesDesde}-{ViernesHasta}");
                return Cadena;
            }
            set
            { ViernesHorario = value; }
        }
        [HorasRequiredAttribute("SabadoHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string SabadoDesde { get; set; }
        public string SabadoHasta { get; set; }
        private string SabadoHorario
        {
            get
            {
                string Cadena = (SabadoDesde + SabadoHasta).ToString();
                Cadena = Cadena == string.Empty ? $"{SABADO} {CERRADO}" : $"{SABADO} {SabadoDesde}-{SabadoHasta}";
                return Cadena;
            }
            set
            { SabadoHorario = value; }
        }
        [HorasRequiredAttribute("DomingoHasta", ErrorMessage = "Debe elegir una ambos horarios")]
        public string DomingoDesde { get; set; }
        public string DomingoHasta { get; set; }
        private string DomingoHorario
        {
            get
            {
                string Cadena = (DomingoDesde + DomingoHasta).ToString();
                Cadena = (Cadena == string.Empty ? $"{DOMINGO} {CERRADO}" : $"{DOMINGO} {DomingoDesde}-{DomingoHasta}");
                return Cadena;
            }
            set
            { DomingoHorario = value; }
        }
        public HorariosViewModel()
        {
            LunesDesde = string.Empty;
            LunesHasta = string.Empty;
            MartesDesde = string.Empty;
            MartesHasta = string.Empty;
            MiercolesDesde = string.Empty;
            MiercolesHasta = string.Empty;
            JuevesDesde = string.Empty;
            JuevesHasta = string.Empty;
            ViernesDesde = string.Empty;
            ViernesHasta = string.Empty;
            SabadoDesde = string.Empty;
            SabadoHasta = string.Empty;
            DomingoDesde = string.Empty;
            DomingoHasta = string.Empty;
        }
        public Horarios ConvertToHorario()
        {
            Horarios Horario = new Horarios
            {
                HorarioID = Id,
                Lunes = LunesHorario,
                Martes = MartesHorario,
                Miercoles = MiercolesHorario,
                Jueves = JuevesHorario,
                Viernes = ViernesHorario,
                Sabado = SabadoHorario,
                Domingo = DomingoHorario,
                NegociosId = NegocioId
            };

            return Horario;
        }
    }
}
