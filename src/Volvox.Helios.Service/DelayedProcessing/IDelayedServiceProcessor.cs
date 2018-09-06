using System.Threading.Tasks;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public interface IDelayedServiceProcessor
    {
        /// <summary>
        ///     Processes all added actions.
        /// </summary>
        Task ProcessAsync();
    }
}