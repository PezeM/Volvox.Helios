using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volvox.Helios.Core.Modules.Common;
using Volvox.Helios.Core.Utilities;

namespace Volvox.Helios.Core.Modules.ReactionRole
{
    public class ReactionRoleModule : Module
    {
        public ReactionRoleModule(IDiscordSettings discordSettings, ILogger<IModule> logger, IConfiguration config)
            : base(discordSettings, logger, config)
        {
        }

        public override Task Init(DiscordSocketClient client)
        {
            return Task.CompletedTask;
        }
    }
}
