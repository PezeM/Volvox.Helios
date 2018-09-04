using System;
using System.Collections.Generic;
using System.Text;

namespace Volvox.Helios.Domain.ModuleSettings
{
    public class LookingForGroupSession
    {
        public Guid Id { get; set; }
        public ulong GuildId { get; set; }
        public string ShortIdentifyer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasMaximumCapacity { get; set; }
        public int MaximumMembers { get; set; }

        public bool HasRoleRestrictions => RoleRestrictions is null || RoleRestrictions.Count == 0;

        public IList<LookingForGroupRoleRestriction> RoleRestrictions { get; set; } =
            new List<LookingForGroupRoleRestriction>();

        public IList<LookingForGroupPlayerRole> PlayerRoles { get; set; } =
            new List<LookingForGroupPlayerRole>();
    }
}
