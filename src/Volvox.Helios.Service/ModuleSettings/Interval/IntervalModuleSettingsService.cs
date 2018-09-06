using System;
using Hangfire;
using Volvox.Helios.Service.DelayedProcessing;

namespace Volvox.Helios.Service.ModuleSettings.Interval
{
    /// <summary>
    /// Save settings to the database in a delayed interval.
    /// </summary>
    public class IntervalModuleSettingsService<T> : IIntervalModuleSettingsService<T> where T : Domain.ModuleSettings.ModuleSettings
    {
        private readonly IVolvoxHeliosActionRepositoryProcessor _volvoxHeliosActionRepositoryProcessor;

        public IntervalModuleSettingsService(IVolvoxHeliosActionRepositoryProcessor volvoxHeliosActionRepositoryProcessor)
        {
            _volvoxHeliosActionRepositoryProcessor = volvoxHeliosActionRepositoryProcessor;
        }

        /// <summary>
        /// Add a setting to be added.
        /// </summary>
        /// <param name="setting"></param>
        public void AddSetting(T setting)
        {
            _volvoxHeliosActionRepositoryProcessor.Push(async c => await c.AddAsync(setting));
        }

        /// <summary>
        /// Save the added settings to the database after the specified delay.
        /// </summary>
        /// <param name="delay">Amount of time to wait before saving to the database.</param>
        public void StartSaveInterval(TimeSpan delay)
        {
            var jobId = BackgroundJob.Schedule(
                () => _volvoxHeliosActionRepositoryProcessor.ProcessAsync(),
                TimeSpan.FromSeconds(5));
        }
    }
}