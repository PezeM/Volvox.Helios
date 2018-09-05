using System.Threading.Tasks;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public interface IDelayedServiceProcessor<in TDelayedItem>
    {
        /// <summary>
        ///     Processes all added actions.
        /// </summary>
        Task ProcessAsync();
    }
}