using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Models.ControlUsers
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public string ClaimAction { get; set; }
    }
}
