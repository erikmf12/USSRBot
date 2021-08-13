using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USSRBot.Commands;
using USSRBot.Models;

namespace USSRBot.Services
{
	public class DiscordCommandService : IDiscordCommandService
	{

		IEnumerable<IBotMessageCommand> _messageCommands;
		IEnumerable<IBotJoinedCommand> _joinedCommands;


		public DiscordCommandService(IServiceProvider serviceProvider)
		{
			_messageCommands = serviceProvider.GetServices<IBotMessageCommand>();
			_joinedCommands = serviceProvider.GetServices<IBotJoinedCommand>();
		}


		public async Task ExecuteMessageCommandsAsync(SocketMessage message)
		{
			foreach(var command in _messageCommands)
			{
				await command.ExecuteCommandAsync(message);
			}
		}


		public async Task ExecuteJoinedCommandsAsync(SocketGuildUser user)
		{
			foreach (var command in _joinedCommands)
			{
				await command.ExcecuteCommandAsync(user);
			}
		}


	}
}
