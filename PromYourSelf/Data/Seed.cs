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
					UserName = "root@gmail.com",
					Email = "root@gmail.com",
					Nombres = "Root",
					Password = RepositorioUsuario.SHA1("1234"),
					Apellidos = "Administrador",
					NormalizedUserName = "root",
					LockoutEnabled = false,
					ModificadoPor = 0,
					EsNulo = false,
					CreadoPor = 0,
					Posicion = Posicion.Administrador.GetDescription(),
					FechaModificacion = DateTime.Now,
					FechaCreacion = DateTime.Now
				};
				var demouser = new Usuarios
				{
					UserName = "demo@gmail.com",
					Email = "demo@gmail.com",
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
				var Usuario3 = new Usuarios
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
					UserName = "ApasLabs@gmail.com",
					EsNulo = false
				};
				var Usuario4 = new Usuarios
				{
					NormalizedEmail = "williambh98@gmail.com".ToUpper(),
					NormalizedUserName = "williambh98".ToUpper(),
					Nombres = "William",
					Apellidos = "Burgos Hernandez",
					LockoutEnabled = false,
					Email = "williambh98@gmail.com",
					Posicion = Posicion.Administrador.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "williambh98@gmail.com",
					EsNulo = false
				};
				var Usuario5 = new Usuarios
				{
					NormalizedEmail = "Usuario5@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario 5",
					Apellidos = "Normal",
					LockoutEnabled = false,
					Email = "Usuario5@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "Usuario5@gmail.com",
					EsNulo = false
				};
				var Usuario6 = new Usuarios
				{
					NormalizedEmail = "Usuario6@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario 6",
					Apellidos = "Normal",
					LockoutEnabled = false,
					Email = "Usuario6@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "Usuario6@gmail.com",
					EsNulo = false
				}; 
				var Usuario7 = new Usuarios
				{
					NormalizedEmail = "Usuario7@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario 7",
					Apellidos = "Normal",
					LockoutEnabled = false,
					Email = "Usuario7@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "Usuario7@gmail.com",
					EsNulo = false
				};
				var Usuario8 = new Usuarios
				{
					NormalizedEmail = "Usuario8@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario 8",
					Apellidos = "Empresa",
					LockoutEnabled = false,
					Email = "Usuario8@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "Usuario8@gmail.com",
					EsNulo = false
				};
				var Usuario9 = new Usuarios
				{
					NormalizedEmail = "Usuario9@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario 9",
					Apellidos = "Empresa",
					LockoutEnabled = false,
					Email = "Usuario9@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "Usuario9@gmail.com",
					EsNulo = false
				};
				var Usuario10 = new Usuarios
				{
					NormalizedEmail = "Usuario10@gmail.com".ToUpper(),
					NormalizedUserName = "usuario".ToUpper(),
					Nombres = "Usuario 10",
					Apellidos = "Empresa",
					LockoutEnabled = false,
					Email = "Usuario10@gmail.com",
					Posicion = Posicion.Normal.GetDescription(),
					Password = RepositorioUsuario.SHA1("1234"),
					Confirmado = true,
					ConcurrencyStamp = DateTime.Now.ToString(),
					UserName = "Usuario10@gmail.com",
					EsNulo = false
				};
				var _userAdminExists = await userManager.FindByNameAsync(poweruser.UserName);
				var _userDemoExists = await userManager.FindByNameAsync(demouser.UserName);
				var _Usuario3Exists = await userManager.FindByNameAsync(Usuario3.UserName);
				var _Usuario4Exists = await userManager.FindByNameAsync(Usuario4.UserName);
				var _Usuario5Exists = await userManager.FindByNameAsync(Usuario5.UserName);
				var _Usuario6Exists = await userManager.FindByNameAsync(Usuario6.UserName);
				var _Usuario7Exists = await userManager.FindByNameAsync(Usuario7.UserName);
				var _Usuario8Exists = await userManager.FindByNameAsync(Usuario8.UserName);
				var _Usuario9Exists = await userManager.FindByNameAsync(Usuario9.UserName);
				var _Usuario10Exists = await userManager.FindByNameAsync(Usuario10.UserName);

				if (_userAdminExists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, poweruser);
				if(_userDemoExists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, demouser);
				
				if (_Usuario3Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario3);
				if (_Usuario4Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario4);
				if (_Usuario5Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario5);
				if (_Usuario6Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario6);
				if (_Usuario7Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario7);
				if (_Usuario8Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario8);
				if (_Usuario9Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario9);
				if (_Usuario10Exists == null)
					await Utils.Utils.SaveUser(userManager, rolManager, Usuario10);
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
