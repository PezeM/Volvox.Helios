using System;
using Microsoft.AspNetCore.Mvc;
using Volvox.Helios.Core.Modules.StreamAnnouncer;
using Volvox.Helios.Domain.ModuleSettings;
using Volvox.Helios.Service.ModuleSettings.Interval;

namespace Volvox.Helios.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIntervalModuleSettingsService<StreamerRoleSettings> _settingsService;

        public HomeController(IIntervalModuleSettingsService<StreamerRoleSettings> settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            for (var i = 1; i <= 100; i++)
            {
                _settingsService.AddSetting(new StreamerRoleSettings
                {
                    GuildId = (ulong)i,
                    Enabled = true,
                    RoleId = (ulong)i
                });
            }

            _settingsService.StartSaveInterval(TimeSpan.FromMinutes(5));

            return View();
        }
        
        public IActionResult Privacy() => View();

        public IActionResult About() => View();
    }
}