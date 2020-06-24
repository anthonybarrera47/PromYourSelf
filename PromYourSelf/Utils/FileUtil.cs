using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;


namespace PromYourSelf.Utils
{
	public static class FileUtil
	{
		public static async Task<string> imageToBase64(IFormFile foto)
		{
			MemoryStream memoryStream = new MemoryStream();
			await foto.CopyToAsync(memoryStream);
			using (var image = Image.FromStream(memoryStream)) {
				using (MemoryStream m = new MemoryStream())
				{
					image.Save(m, image.RawFormat); byte[] imageBytes = m.ToArray(); // Convert byte[] to Base64 String 
					string base64String = Convert.ToBase64String(imageBytes); 
					return base64String;
				}
			}
		}
	}
		
}
