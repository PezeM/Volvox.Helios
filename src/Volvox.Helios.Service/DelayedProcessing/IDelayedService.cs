using System.Threading.Tasks;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public interface IDelayedService<in TDelayedItem>
    {
        void Push(TDelayedItem delayedItem);

        /// <summary>
        ///     Processes all added actions.
        /// </summary>
        Task ProcessAsync();
    }
}