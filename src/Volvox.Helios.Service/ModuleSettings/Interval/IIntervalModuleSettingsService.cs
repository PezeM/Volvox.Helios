using System;

namespace Volvox.Helios.Service.ModuleSettings.Interval
{
    /// <summary>
    /// Save settings to the database in a delayed interval.
    /// </summary>
    public interface IIntervalModuleSettingsService<T> where T : Domain.ModuleSettings.ModuleSettings
    {
        /// <summary>
        /// Add a setting to be added.
        /// </summary>
        /// <param name="setting"></param>
        void AddSetting(T setting);

        /// <summary>
        /// Save the changes to the database after the delay.
        /// </summary>
        /// <param name="delay">Amount of time to wait.</param>
        void StartSaveInterval(TimeSpan delay );
    }
}