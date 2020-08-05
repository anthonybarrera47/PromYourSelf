﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using PromYourSelf.Utils;

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
			this.mensajes = await this.db.Mensaje.Where<Mensajes>(x => x.UsuarioID == usuarioId).ToListAsync();

			List<int> ids = this.mensajes.Select(x => x.ReceptorID).Distinct().ToList();


			this.negocios = this.db.Negocios.Where<Negocios>(c => ids.Any(x => x == c.NegocioID)).ToList();

			return View(new ChatViewModel(negocios));
		}

		public ContentViewComponentResult GetMessages(int negocioId)
		{
			List<Mensajes> _mensajes = this.mensajes.Where(x => x.ReceptorID == negocioId).ToList();
			return new ContentViewComponentResult(content: JsonConvert.SerializeObject(_mensajes));
		}
	
	
	}
	

	public class ChatViewModel
	{		
		public List<Negocios> negocios = new List<Negocios>();
		public ChatViewModel(List<Negocios> lnegocios)
		{			
			this.negocios = lnegocios;
		}
	}
}