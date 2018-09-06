using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public interface IVolvoxHeliosActionRepositoryProcessor
    {
        IList<Action<VolvoxHeliosContext>> Get();

        void Push(Action<VolvoxHeliosContext> delayedItem);

        Task ProcessAsync();
    }
}