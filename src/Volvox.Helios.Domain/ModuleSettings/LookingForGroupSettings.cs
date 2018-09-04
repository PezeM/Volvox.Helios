using System;
using System.Collections.Generic;
using System.Text;

namespace Volvox.Helios.Domain.ModuleSettings
{
    public class LookingForGroupSettings : ModuleSettings
    {
        public ICollection<LookingForGroupSession> Sessions { get; set; } =
            new List<LookingForGroupSession>();
    }
}
