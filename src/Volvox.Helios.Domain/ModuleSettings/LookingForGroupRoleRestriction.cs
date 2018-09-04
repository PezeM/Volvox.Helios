using System;
using System.Collections.Generic;
using System.Text;

namespace Volvox.Helios.Domain.ModuleSettings
{
    public class LookingForGroupRoleRestriction
    {
        public Guid Id { get; set; }
        public ulong GuildId { get; set; }
        public Guid SessionId { get; set; }
        public ulong RoleId { get; set; }
    }
}
