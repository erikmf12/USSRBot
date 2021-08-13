using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using USSRBot.Commands;
using USSRBot.Models;
using USSRBot.Services;

namespace USSRBot
{
	public class Program
	{

		public static void Main(string[] args)
		{
			CreateDefaultHost()
				.Build()
				.Run();
		}

		private static IHostBuilder CreateDefaultHost() =>
			Host.CreateDefaultBuilder()
			.ConfigureServices((builderContext, services) =>
			 {
				 // add all custom commands here with any of these interfaces:
				 // IBotJoinedCommand
				 // IBotMessageCommand

				 services.AddTransient<IBotMessageCommand, WelcomeCommand>();

				 // these are the vital parts of the app:
				 services.AddSingleton<IDiscordCommandService, DiscordCommandService>();
				 services.AddHostedService<DiscordClientManager>();

			 });


	}
}
