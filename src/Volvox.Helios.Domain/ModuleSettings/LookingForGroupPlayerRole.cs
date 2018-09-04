using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volvox.Helios.Domain.ModuleSettings
{
    public class LookingForGroupPlayerRole
    {
        public Guid Id { get; set; }
        public ulong GuildId { get; set; }
        public string Category { get; set; }
    }
}
