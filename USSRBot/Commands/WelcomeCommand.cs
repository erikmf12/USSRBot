using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using USSRBot.Models;

namespace USSRBot.Commands
{
	public class WelcomeCommand : IBotMessageCommand
	{
		public Task ExecuteCommandAsync(SocketMessage message)
		{
			return Task.CompletedTask;
		}
	}
}
