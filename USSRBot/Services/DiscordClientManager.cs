using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace USSRBot.Services
{
	public class DiscordClientManager : IHostedService
	{

		private DiscordSocketClient _client;

		private readonly string _token;
		private readonly IDiscordCommandService _commandService;
		private readonly ILogger<DiscordClientManager> _logger;

		public DiscordClientManager(IDiscordCommandService commandService,
			ILogger<DiscordClientManager> logger,
			IConfiguration config)
		{
			_client = new DiscordSocketClient();
			_token = config["Token"];
			SubscribeHandlers();
			
			_commandService = commandService;
			_logger = logger;
		}

		private void SubscribeHandlers()
		{
			_client.MessageReceived += _client_MessageReceived;
			_client.UserJoined += _client_UserJoined;
			_client.Log += _client_Log;
		}



		private async Task _client_UserJoined(SocketGuildUser arg)
		{
			await _commandService.ExecuteJoinedCommandsAsync(arg);
		}

		private Task _client_Log(LogMessage arg)
		{
			_logger.LogInformation(arg.Message);
			return Task.CompletedTask;
		}

		private async Task _client_MessageReceived(SocketMessage arg)
		{
			await _commandService.ExecuteMessageCommandsAsync(arg);
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await _client.LoginAsync(TokenType.Bot, _token);

			await _client.StartAsync();
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
