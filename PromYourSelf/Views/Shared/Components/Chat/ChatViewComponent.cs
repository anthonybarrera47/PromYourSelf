using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;

namespace PromYourSelf.Views.Shared.Components.Chat
{
	public class ChatViewComponent : ViewComponent
	{
		private readonly Contexto db;
		int empresaIdActual;
		List<Mensajes> mensajes = new List<Mensajes>();
		List<Negocios> negocios = new List<Negocios>();

		public ChatViewComponent(Contexto contexto)
		{
			db = contexto;
		}

		public async Task<IViewComponentResult> InvokeAsync(
		int usuarioId)
		{
			this.mensajes = await this.db.Mensaje.Where<Mensajes>(x => x.UsuarioID == usuarioId || x.NegocioID == usuarioId).ToListAsync();

			List<int> ids = this.mensajes.Select(x => x.NegocioID).Distinct().ToList();


			this.negocios = this.db.Negocios.Where<Negocios>(c => ids.Any(x => x == c.NegocioID)).ToList();

			return View(new ChatViewModel(mensajes, negocios));
		}

		public ContentViewComponentResult GetMessages(int negocioId)
		{
			List<Mensajes> _mensajes = this.mensajes.Where(x => x.NegocioID == negocioId).ToList();
			return new ContentViewComponentResult(content: JsonConvert.SerializeObject(_mensajes));
		}
	
	
	}
	

	public class ChatViewModel
	{
		public List<Mensajes> mensajes = new List<Mensajes>();
		public List<Negocios> negocios = new List<Negocios>();
		public ChatViewModel(List<Mensajes> lmensajes, List<Negocios> lnegocios)
		{
			this.mensajes = lmensajes;
			this.negocios = lnegocios;
		}
	}
}
