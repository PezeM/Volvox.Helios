using System;
using System.Collections.Generic;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public interface IVolvoxHeliosActionRepository
    {
        IList<Action<VolvoxHeliosContext>> Get();

        void Push(Action<VolvoxHeliosContext> delayedItem);
    }
}