using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models.ControlUsers
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public string ClaimAction { get; set; }
    }
}
