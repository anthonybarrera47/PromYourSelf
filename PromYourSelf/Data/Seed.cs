using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PromYourSelf.Utils;
using PromYourSelf.BLL;
using BLL;

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
					Email = "root@nose.com",
					Nombres = "Root",
					Password = "1234",
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

				

				var demouser = new Usuarios
				{
					UserName = "demo",
					Email = "demo@nose.com",
					Nombres = "Demo",
					Password = "1234",
					Apellidos = "Demo ",
					NormalizedUserName = "demo",
					LockoutEnabled = false,
					ModificadoPor = 0,
					EsNulo = false,
					CreadoPor = 0,
					Posicion = "Normal",
					FechaModificacion = DateTime.Now,
					FechaCreacion = DateTime.Now
				};
				var _userAdminExists = await userManager.FindByNameAsync(poweruser.UserName);
				var _userDemoExists = await userManager.FindByNameAsync(demouser.UserName);
				if (_userAdminExists == null)
				{
					await SaveUser(userManager, rolManager, poweruser);
				}

				if(_userDemoExists == null)
				{
					await SaveUser(userManager, rolManager, demouser);
				}

				var adminUserExists = await userManager.FindByNameAsync("root");			

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		

		public static async Task SaveUser(UserManager<Usuarios> userManager, RoleManager<Roles> rolManager,  Usuarios usuario)
		{
			var result = await userManager.CreateAsync(usuario, "1234");
			string posicion = Posicion.Administrador.GetDescription() == "Administrador" ? "Administrador" : "Normal";
			if (result.Succeeded)
			{
				await userManager.AddClaimAsync(usuario, new Claim("Nombres", usuario.Nombres));
				await userManager.AddClaimAsync(usuario, new Claim("Posicion", usuario.Posicion));
				Roles rol = await rolManager.FindByNameAsync(posicion);
				if (rol == null)
				{
					
					rol = new Roles() { Name = posicion };
				}
				var r = await rolManager.CreateAsync(rol);
				if (r.Succeeded)
				{
					await userManager.AddToRoleAsync(usuario, posicion);
				}
				Console.WriteLine("Todo Bien.");
			}

		}
	}
}
