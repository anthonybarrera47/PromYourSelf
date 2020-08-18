using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Data.Common;
using Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Net.Mail;

namespace PromYourSelf.Utils
{
	public static class Utils
	{
        public static async Task<string> ImageToBase64(IFormFile foto)
		{
			if (foto != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				await foto.CopyToAsync(memoryStream);
				using (var image = Image.FromStream(memoryStream))
				{
					using (MemoryStream m = new MemoryStream())
					{
						image.Save(m, image.RawFormat); byte[] imageBytes = m.ToArray(); // Convert byte[] to Base64 String 
						string base64String = Convert.ToBase64String(imageBytes);
						return base64String;
					}
				}
			}
			else
				return string.Empty;

		}
		public static string GetUserID(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));

			return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}

		/// <summary>
		/// Busca en el claimPrincipal el username del usuario
		/// </summary>
		/// <param name="principal"></param>
		/// <returns></returns>
		public static string GetUserName(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));
			return principal.FindFirst(ClaimTypes.Name)?.Value;
		}

		public static string GetNombre(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));
			return principal.FindFirst(c => c.Type == TypeClaims.Nombres.ToString("G"))?.Value;
		}
		public static string GetEmpresaID(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));
			return principal.FindFirst(c => c.Type == TypeClaims.Empresa.ToString("G"))?.Value;
		}
		public static string GetPosicion(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));
			return principal.FindFirst(c => c.Type == TypeClaims.Posicion.ToString("G"))?.Value;
		}
		public static string GetFoto(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));
			return principal.FindFirst(c => c.Type == TypeClaims.Foto.ToString("G"))?.Value;
		}

		public static bool IsValidEmail(this string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			try
			{
				// Normalize the domain
				email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
									  RegexOptions.None, TimeSpan.FromMilliseconds(200));

				// Examines the domain part of the email and normalizes it.
				string DomainMapper(Match match)
				{
					// Use IdnMapping class to convert Unicode domain names.
					var idn = new IdnMapping();

					// Pull out and process domain name (throws ArgumentException on invalid)
					var domainName = idn.GetAscii(match.Groups[2].Value);

					return match.Groups[1].Value + domainName;
				}
			}
			catch (RegexMatchTimeoutException e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
			catch// (ArgumentException e)
			{
				return false;
			}

			try
			{
				return Regex.IsMatch(email,
					@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
					@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
					RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			}
			catch (RegexMatchTimeoutException)
			{
				return false;
			}
		}
		public static PropertyInfo[] GetProperties(object obj)
		{
			return obj.GetType().GetProperties();
		}

		public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
		{
			using (var context = new Contexto())
			{
				using (var command = context.Database.GetDbConnection().CreateCommand())
				{
					command.CommandText = query;
					command.CommandType = CommandType.Text;

					context.Database.OpenConnection();

					using (var result = command.ExecuteReader())
					{
						var entities = new List<T>();

						while (result.Read())
						{
							entities.Add(map(result));
						}

						return entities;
					}
				}
			}
		}
		public static void SeedCuidades(MigrationBuilder migrationBuilder)
        {
			//Utils.Utils.SeedCuidades(migrationBuilder);
			string Path = Environment.CurrentDirectory;
			string sql = File.ReadAllText($@"{Path}\Data\Ciudades.sql");
			migrationBuilder.Sql(sql);
		}
		public static string GenerarToken(int longitud = 8)
		{
            Guid miGuid = Guid.NewGuid();
			string token = Convert.ToBase64String(miGuid.ToByteArray());
			token = token.Replace("=", "").Replace("+", "");
            string str = token.Substring(0, longitud);
            return str;
		}
		public static async Task SendMail(MailMessage Mail)
        {
			SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new System.Net.NetworkCredential("proyectoaplicada2@gmail.com", "@P123456"),
				EnableSsl = true
			};
			await SmtpServer.SendMailAsync(Mail);
		}
	}


}
