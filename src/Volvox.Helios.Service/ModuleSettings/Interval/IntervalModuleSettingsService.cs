using Hangfire;
using Volvox.Helios.Service.DelayedProcessing;

namespace Volvox.Helios.Service.ModuleSettings.Interval
{
    /// <summary>
    ///     Save settings to the database in a delayed interval.
    /// </summary>
    public class IntervalModuleSettingsService<T> : IIntervalModuleSettingsService<T>
        where T : Domain.ModuleSettings.ModuleSettings
    {
        private const string RecurringJobId = "IntervalSettingsService:Save";
        private readonly IVolvoxHeliosActionRepositoryProcessor _volvoxHeliosActionRepositoryProcessor;

        public IntervalModuleSettingsService(
            IVolvoxHeliosActionRepositoryProcessor volvoxHeliosActionRepositoryProcessor)
        {
            _volvoxHeliosActionRepositoryProcessor = volvoxHeliosActionRepositoryProcessor;
        }

        /// <summary>
        ///     Add a setting to be added after the saving interval.
        /// </summary>
        /// <param name="setting">Setting to be added.</param>
        public void AddSetting(T setting)
        {
            _volvoxHeliosActionRepositoryProcessor.Push(async c => await c.AddAsync(setting));
        }

        /// <summary>
        ///     Save the added settings to the database on a recurring job.
        /// </summary>
        /// <param name="delay">Amount of time to wait before saving to the database. If not set will default to minutely.</param>
        public void StartSaveInterval(string delay = "")
        {
            if (string.IsNullOrWhiteSpace(delay))
                delay = Cron.Minutely();

            RecurringJob.AddOrUpdate(RecurringJobId, () => _volvoxHeliosActionRepositoryProcessor.ProcessAsync(),
                delay);
        }
    }
}