namespace Volvox.Helios.Service.ModuleSettings.Interval
{
    /// <summary>
    ///     Save settings to the database in a delayed interval.
    /// </summary>
    public interface IIntervalModuleSettingsService<T> where T : Domain.ModuleSettings.ModuleSettings
    {
        /// <summary>
        ///     Add a setting to be added after the saving interval.
        /// </summary>
        /// <param name="setting">Setting to be added.</param>
        void AddSetting(T setting);

        /// <summary>
        ///     Save the added settings to the database on a recurring job.
        /// </summary>
        /// <param name="delay">Amount of time to wait before saving to the database. If not set will default to minutely.</param>
        void StartSaveInterval(string delay = "");
    }
}