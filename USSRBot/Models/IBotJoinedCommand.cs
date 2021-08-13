using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace USSRBot.Models
{
	public interface IBotJoinedCommand
	{
		Task ExcecuteCommandAsync(SocketGuildUser user);
	}
}
