using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;
using USSRBot.Commands;

namespace USSRBot.Services
{
	public interface IDiscordCommandService
	{
		Task ExecuteMessageCommandsAsync(SocketMessage message);
		Task ExecuteJoinedCommandsAsync(SocketGuildUser user);
	}
}