using Hangfire;
using Volvox.Helios.Service.DelayedProcessing;

namespace Volvox.Helios.Service.ModuleSettings.Interval
{
    /// <summary>
    /// Save settings to the database in a delayed interval.
    /// </summary>
    public class IntervalModuleSettingsService<T> : IIntervalModuleSettingsService<T> where T : Domain.ModuleSettings.ModuleSettings
    {
        private readonly VolvoxHeliosActionRepositoryProcessor _volvoxHeliosActionRepositoryProcessor;
        private readonly VolvoxHeliosActionRepository _volvoxHeliosActionRepository;

        public IntervalModuleSettingsService(VolvoxHeliosActionRepositoryProcessor volvoxHeliosActionRepositoryProcessor, VolvoxHeliosActionRepository volvoxHeliosActionRepository)
        {
            _volvoxHeliosActionRepositoryProcessor = volvoxHeliosActionRepositoryProcessor;
            _volvoxHeliosActionRepository = volvoxHeliosActionRepository;
        }

        /// <summary>
        /// Add a setting to be added.
        /// </summary>
        /// <param name="setting"></param>
        public void AddSetting(T setting)
        {
            _volvoxHeliosActionRepository.Push(async c => await c.AddAsync(setting));
        }

        /// <summary>
        /// Save the changes to the database after the delay.
        /// </summary>
        /// <param name="delay">Amount of time to wait.</param>
        public void StartSaveInterval(string delay = "*/5 * * * *")
        {
            RecurringJob.AddOrUpdate(() => _volvoxHeliosActionRepositoryProcessor.ProcessAsync(), delay);
        }
    }
}