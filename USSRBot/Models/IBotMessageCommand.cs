using Discord.WebSocket;
using System.Threading.Tasks;

namespace USSRBot.Models
{
	public interface IBotMessageCommand
	{

		Task ExecuteCommandAsync(SocketMessage message);


	}
}