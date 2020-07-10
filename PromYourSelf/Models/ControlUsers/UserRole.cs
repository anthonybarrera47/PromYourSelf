using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models.ControlUsers
{
    public class UserRole :  IdentityUserRole<int>
    {
        public Usuarios User { get; set; }
        public Roles Role { get; set; }
        
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool EsNulo { get; set; }
        [NotMapped]
        public bool IsUpdate { get; set; }
    }
}
