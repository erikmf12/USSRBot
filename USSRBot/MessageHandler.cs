using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace USSRBot
{
	public class MessageHandler
	{


		private List<Func<SocketMessage, Task>> _handlers = new List<Func<SocketMessage, Task>>();


		public void RegisterHandler(Func<SocketMessage, Task> action)
		{
			_handlers.Add(action);
		}


		public async Task HandleAsync(SocketMessage m)
		{
			foreach(var handler in _handlers)
			{
				await handler(m);
			}

		}

	}
}
