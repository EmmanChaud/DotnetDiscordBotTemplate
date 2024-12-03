using Common.Interfaces;
using Common.Options;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Services.Services
{
    public class DiscordService : IDiscordService
    {
        private readonly DiscordSocketClient _client;
        private readonly DiscordClientOptions _configuration;
        public DiscordService(DiscordSocketClient client, IOptions<DiscordClientOptions> configuration)
        {
            _client = client;
            _configuration = configuration.Value;
            _client.MessageReceived += HandleMessage;
        }

        public async Task RunBotASync()
        {
            _client.Log += LogAsync;

            await _client.LoginAsync(TokenType.Bot, _configuration.DiscordBotToken);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }


        private async Task HandleMessage(SocketMessage message)
        {
            if (message is not SocketUserMessage userMessage || message.Author.IsBot)
                return;

            if (userMessage.Content.Equals("ping", StringComparison.CurrentCultureIgnoreCase))
            {
                await userMessage.Channel.SendMessageAsync("pong");
            }
        }

        public Task SendMessageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
