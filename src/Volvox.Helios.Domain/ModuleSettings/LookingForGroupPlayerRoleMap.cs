using System;
using System.Collections.Generic;
using System.Text;

namespace Volvox.Helios.Domain.ModuleSettings
{
    public class LookingForGroupPlayerRoleMap
    {
        public ulong GuildId { get; set; }
        public Guid PlayerRoleId { get; set; }
        public Guid SessionId { get; set; }
    }
}
