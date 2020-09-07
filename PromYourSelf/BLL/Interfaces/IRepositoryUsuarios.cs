using BLL;
using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepositoryUsuarios : IRepository<Usuarios>
    {
        Task<Usuarios> GetUserInfoByEmail(string email);
        Task<string> GetUserNameById(int Id);
        Task<Usuarios> GetUserInfoById(int Id);
        
        Task UpdateClaimsUser(SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager,Usuarios usuarios);
        Task RemoveClaimsUser(SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager, Usuarios usuarios);
    }
}
