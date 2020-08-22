using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using BasicChat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Models;
using PromYourSelf.Models.ControlUsers;
using PromYourSelf.Utils;

namespace SignalRChat
{
	public class ChatHub : Hub
	{
		private readonly ClaimsPrincipal User;
		public ChatHub(IHttpContextAccessor accesor)
		{
			this.User = accesor.HttpContext.User;
		}
		private readonly static ConnectionMapping<string> _connections =
		   new ConnectionMapping<string>();		
		public void Send(string receptorId, string mensaje)
		{
			string name = this.User.GetUserID();

			foreach (var connectionId in _connections.GetConnections(receptorId))
			{
				Clients.Client(connectionId).SendAsync("newMessage");
			}
		}

		public override Task OnConnectedAsync()
		{
			try
			{
				string name = User.GetUserID().ToString();

				_connections.Add(name, Context.ConnectionId);

				
			}catch(Exception e)
			{

			}

			return base.OnConnectedAsync();
		}		
		public override Task OnDisconnectedAsync(Exception ex)
		{
			string name = Context.User.Identity.Name;

			_connections.Remove(name, Context.ConnectionId);

			return base.OnDisconnectedAsync(ex);
		}

		//public override Task OnReconnected()
		//{
		//	string name = Context.User.Identity.Name;

		//	if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
		//	{
		//		_connections.Add(name, Context.ConnectionId);
		//	}

		//	return base.OnReconnected();
		//}
	}
}


namespace BasicChat
{
	public class ConnectionMapping<T>
	{
		private readonly Dictionary<T, HashSet<string>> _connections =
			new Dictionary<T, HashSet<string>>();

		public int Count
		{
			get
			{
				return _connections.Count;
			}
		}

		public void Add(T key, string connectionId)
		{
			lock (_connections)
			{
				HashSet<string> connections;
				if (!_connections.TryGetValue(key, out connections))
				{
					connections = new HashSet<string>();
					_connections.Add(key, connections);
				}

				lock (connections)
				{
					connections.Add(connectionId);
				}
			}
		}

		public IEnumerable<string> GetConnections(T key)
		{
			HashSet<string> connections;
			if (_connections.TryGetValue(key, out connections))
			{
				return connections;
			}

			return Enumerable.Empty<string>();
		}

		public void Remove(T key, string connectionId)
		{
				try
			{
				lock (_connections)
				{
					HashSet<string> connections;
					if (!_connections.TryGetValue(key, out connections))
					{
						return;
					}

					lock (connections)
					{
						connections.Remove(connectionId);

						if (connections.Count == 0)
						{
							_connections.Remove(key);
						}
					}
				}
			}catch(Exception e) { }
		}
	}
}
