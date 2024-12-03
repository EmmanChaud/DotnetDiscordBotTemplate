namespace Common.Interfaces
{
    public interface IDiscordService
    {
        Task RunBotASync();
        Task SendMessageAsync();
    }
}
