using Microsoft.AspNetCore.Mvc;
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
		int usuarioId = 0, int negocioId = 0)
		{	if(usuarioId <= 0) return View(new ChatViewModel(new List<Negocios>()));
			Negocios NuevoChat = await this.db.Negocios.Where<Negocios>(x => x.NegocioID == negocioId).FirstOrDefaultAsync();
			if (negocioId > 0)
			{				
				if(NuevoChat != null)
				{
					List<Mensajes> listaMensajes = await this.db.Mensaje.Where(x => x.UsuarioID == NuevoChat.UsuarioID && x.ReceptorID == usuarioId).ToListAsync();
					if(listaMensajes.Count <= 0)
					{
						Mensajes MensajeInicial = new Mensajes()
						{
							Contenido = "Bienvenido a " + NuevoChat.NombreComercial,
							UsuarioID = NuevoChat.UsuarioID,
							ReceptorID = usuarioId,
							Tipo = TipoContenido.Texto,
							EstadoMensaje = EstadoMensaje.Leido,

						};
						await this.db.Mensaje.AddAsync(MensajeInicial);
						bool guardado = await this.db.SaveChangesAsync() > 0;
					}
					
				}
			}
			this.mensajes = await this.db.Mensaje.Where<Mensajes>(x => x.UsuarioID == usuarioId || x.ReceptorID == usuarioId).ToListAsync();

			List<int> ids = this.mensajes.Select(x => x.ReceptorID).Distinct().ToList();

			if(negocioId > 0)
			{
				this.negocios = new List<Negocios>();
				this.negocios.Add(NuevoChat);
			} else
			{
				this.negocios = this.db.Negocios.Where<Negocios>(c => ids.Any(x => x == c.NegocioID)).ToList();
			}
			
			

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
