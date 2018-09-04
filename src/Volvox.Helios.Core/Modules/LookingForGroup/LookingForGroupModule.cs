using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volvox.Helios.Core.Modules.Common;
using Volvox.Helios.Core.Utilities;
using Volvox.Helios.Domain.ModuleSettings;
using Volvox.Helios.Service.ModuleSettings;

namespace Volvox.Helios.Core.Modules.LookingForGroup
{
    public class LookingForGroupModule : Module
    {
        IDictionary<ulong, Guid> _currentOpenLfgs;
        IModuleSettingsService<LookingForGroupSettings> _lfgSettings;

        public LookingForGroupModule(IDiscordSettings discordSettings,
            ILogger<LookingForGroupModule> logger,
            IConfiguration config,
            IModuleSettingsService<LookingForGroupSettings> lfgSettings) : base(discordSettings, logger, config)
        {
            _lfgSettings = lfgSettings;
        }

        public async override Task Init(DiscordSocketClient client)
        {

            client.MessageReceived += HandleNewMessage;
        }

        async Task HandleNewMessage(SocketMessage message)
        {
            if (message.Author.IsBot)
                return;

            if(message.Author is SocketGuildUser sgu)
            {
                var settings = await _lfgSettings.GetSettingsByGuild(sgu.Guild.Id);
                if(settings.Enabled)
                    await message.Channel.SendMessageAsync("Received");
            }
        }
    }
}
