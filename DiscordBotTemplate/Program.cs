using Common.Interfaces;
using Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

var config = builder.Configuration.AddUserSecrets<Program>().Build();

var services = builder.Services.ConfigureServices(config).BuildServiceProvider();

var client = services.GetRequiredService<IDiscordService>();

await client.RunBotASync();