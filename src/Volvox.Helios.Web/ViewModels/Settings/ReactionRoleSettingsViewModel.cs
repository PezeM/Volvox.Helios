﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volvox.Helios.Web.ViewModels.Settings
{
    public class ReactionRoleSettingsViewModel
    {
        public ulong GuildId { get; set; }

        [Required]
        [DisplayName("Enabled")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }
    }
}
