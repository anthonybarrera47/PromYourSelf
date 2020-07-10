using Microsoft.AspNetCore.Identity;
using Models;
using PromYourSelf.Models.ControlUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models
{
    public class Roles : IdentityRole<int>
    {
        public Roles() : base()
        {
        }
        public bool EsNulo { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
