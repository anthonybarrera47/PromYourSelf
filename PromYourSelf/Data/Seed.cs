using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PromYourSelf.Data
{
    public class Seed
    {
        public static async Task CreateUserAndRoles(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<Usuarios>>();
            var rolManager = serviceProvider.GetService<RoleManager<Roles>>();
            //Crear el super usuario del website basado en la informacion colocada
            // en appsettings.json

            try
            {
                var poweruser = new Usuarios
                {
                    UserName = "root",
                    Password = "1234567",
                    Email = "root@nose.com",
                    Nombres = "Root",
                    Apellidos = "Root ",
                    NormalizedUserName = "root",
                    LockoutEnabled = false,
                    ModificadoPor = 0,
                    EsNulo = false,
                    CreadoPor = 0,
                    Posicion = "Administrador",
                    FechaModificacion = DateTime.Now,
                    FechaCreacion = DateTime.Now
                };
                var _user = await userManager.FindByNameAsync(poweruser.UserName);
                if (_user == null)
                {
                    var result = await userManager.CreateAsync(poweruser, "1234567");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(poweruser, new Claim("Nombre", poweruser.Nombres));
                        await userManager.AddClaimAsync(poweruser, new Claim("Posicion", poweruser.Posicion));
                        Roles rol = await rolManager.FindByNameAsync("Administrador");
                        if (rol == null)
                        {
                            rol = new Roles() { Name = "Administrador" };
                        }
                        var r = await rolManager.CreateAsync(rol);
                        if (r.Succeeded)
                        {
                            await userManager.AddToRoleAsync(poweruser, "Administrador");
                        }
                        Console.WriteLine("Todo Bien.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
