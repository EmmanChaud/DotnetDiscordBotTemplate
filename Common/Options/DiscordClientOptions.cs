using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Options
{
    public class DiscordClientOptions
    {
        public const string Key = "DiscordClient";

        public string DiscordBotToken { get; set; } = String.Empty;
        public string DiscordChannelId { get; set; } = String.Empty;
    }
}
