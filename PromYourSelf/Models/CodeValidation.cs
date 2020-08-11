using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models
{
    public class CodeValidation
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioID { get; set; }
        public string Codigo { get; set; }
        public string Email { get; set; }
        public DateTime TiempoExpiracion { get; set; }

        public CodeValidation()
        {
            Id = 0;
            UsuarioID = 0;
            Codigo = string.Empty;
            Email = string.Empty;
            TiempoExpiracion = DateTime.Now;
        }
    }
}
