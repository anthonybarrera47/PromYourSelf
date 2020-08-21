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
					Password = RepositorioUsuario.SHA1("1234"),
					Apellidos = "Root ",
					NormalizedUserName = "root",
					LockoutEnabled = false,
					ModificadoPor = 0,
					EsNulo = false,
					CreadoPor = 0,
					Posicion = Posicion.Normal.GetDescription(),
					FechaModificacion = DateTime.Now,
					FechaCreacion = DateTime.Now
				};
				var demouser = new Usuarios
				{
					UserName = "demo",
					Email = "demo@nose.com",
					Nombres = "Demo",
					Password = RepositorioUsuario.SHA1("1234"),
					Apellidos = "Demo ",
					NormalizedUserName = "demo",
					LockoutEnabled = false,
					ModificadoPor = 0,
					EsNulo = false,
					CreadoPor = 0,
					Posicion = Posicion.Normal.GetDescription(),
					FechaModificacion = DateTime.Now,
					FechaCreacion = DateTime.Now
				};
				var Usuario1 = new Usuarios
				{
					Nombres = "Luis Felipe",
					NormalizedEmail = "ApasLabs@gmail.com".ToUpper(),
					NormalizedUserName = "ApasLabs".ToUpper(),
					Apellidos = " Muños Florez",
					Email = "ApasLabs@gmail.com",
					LockoutEnabled = false,
					Posicion = Posicion.Administrador.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "ApasLabs",
					EsNulo = false
				};
				var Usuario2 = new Usuarios
				{
					NormalizedEmail = "williamelnene@gmail.com".ToUpper(),
					NormalizedUserName = "williambh98".ToUpper(),
					Nombres = "William",
					Apellidos = "Burgos Hernandez",
					LockoutEnabled = false,
					Email = "williamelnene@gmail.com",
					Posicion = Posicion.Administrador.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "williambh98",
					EsNulo = false
				};
				var Usuario3 = new Usuarios
				{
					NormalizedEmail = "usuarionoimai@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario",
					Apellidos = "Normal",
					LockoutEnabled = false,
					Email = "usuarionoimai@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "usuario",
					EsNulo = false
				};

				var _userAdminExists = await userManager.FindByNameAsync(poweruser.UserName);
				var _userDemoExists = await userManager.FindByNameAsync(demouser.UserName);
				var _Usuario1Exists = await userManager.FindByNameAsync(Usuario1.UserName);
				var _Usuario2Exists = await userManager.FindByNameAsync(Usuario2.UserName);
				var _Usuario3Exists = await userManager.FindByNameAsync(Usuario3.UserName);

				if (_userAdminExists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, poweruser);
				if(_userDemoExists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, demouser);
				if (_Usuario1Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario1);
				if (_Usuario2Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario2);
				if (_Usuario3Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario3);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
