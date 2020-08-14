using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace PromYourSelf.Models
{
    public class PasswordGenerator : CamposEstandar
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FakePassWord { get; set; }
        public DateTime TimeExpire{ get; set; }
        public bool IsUsed { get; set; }
    }
}
