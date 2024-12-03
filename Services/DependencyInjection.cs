using Common.Interfaces;
using Common.Options;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration configuration)
        {
            return service.AddSingleton(provider =>
            {
                var config = new DiscordSocketConfig
                {
                    GatewayIntents = Discord.GatewayIntents.MessageContent | Discord.GatewayIntents.AllUnprivileged
                };
                return new DiscordSocketClient(config);
            })
            .AddScoped<IDiscordService, DiscordService>()
            .Configure<DiscordClientOptions>(configuration.GetSection(DiscordClientOptions.Key));
        }
    }
}
