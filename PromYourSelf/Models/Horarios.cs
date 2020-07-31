using PromYourSelf.Utils;
using PromYourSelf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Models
{
    public class Horarios
    {
        [Key]
        public int HorarioID { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
        public string Domingo { get; set; }
        public int NegociosId { get; set; }

        public HorariosViewModel ConvertToHorariosViewModel()
        {
            HorariosViewModel Horarios = new HorariosViewModel()
            {
                Id = HorarioID,
                LunesDesde = GetHoraFromString(Lunes, HorariosViewModel.LUNES.ToUpperInvariant(), true, false),
                LunesHasta = GetHoraFromString(Lunes, HorariosViewModel.LUNES.ToUpperInvariant(), false, true),
                MartesDesde = GetHoraFromString(Martes, HorariosViewModel.MARTES.ToUpperInvariant(), true, false),
                MartesHasta = GetHoraFromString(Martes, HorariosViewModel.MARTES.ToUpperInvariant(), false, true),
                MiercolesDesde = GetHoraFromString(Miercoles, HorariosViewModel.MIERCOLES.ToUpperInvariant(), true, false),
                MiercolesHasta = GetHoraFromString(Miercoles, HorariosViewModel.MIERCOLES.ToUpperInvariant(), false, true),
                JuevesDesde = GetHoraFromString(Jueves, HorariosViewModel.JUEVES.ToUpperInvariant(), true, false),
                JuevesHasta = GetHoraFromString(Jueves, HorariosViewModel.JUEVES.ToUpperInvariant(), false, true),
                ViernesDesde = GetHoraFromString(Viernes, HorariosViewModel.VIERNES.ToUpperInvariant(), true, false),
                ViernesHasta = GetHoraFromString(Viernes, HorariosViewModel.VIERNES.ToUpperInvariant(), false, true),
                SabadoDesde = GetHoraFromString(Sabado, HorariosViewModel.SABADO.ToUpperInvariant(), true, false),
                SabadoHasta = GetHoraFromString(Sabado, HorariosViewModel.SABADO.ToUpperInvariant(), false, true),
                DomingoDesde = GetHoraFromString(Domingo, HorariosViewModel.DOMINGO.ToUpperInvariant(), true, false),
                DomingoHasta = GetHoraFromString(Domingo, HorariosViewModel.DOMINGO.ToUpperInvariant(), false, true)
            };

            return Horarios;
        }
        private string GetHoraFromString(string Horario,string Dia,bool EsDesde,bool EsHasta)
        {
            string str = Horario.ToUpper();

            str = str.Replace(Dia.ToUpper(), "").Trim();

            if (EsDesde)
                str = str.Substring(0, 5);
            else if (EsHasta)
                str = str.Substring(str.IndexOf("-")+1, 5);
            return str;
        }
        
    }
}
