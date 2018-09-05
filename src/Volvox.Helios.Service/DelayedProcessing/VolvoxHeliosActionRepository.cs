using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public class VolvoxHeliosActionRepository : IRepository<Action<VolvoxHeliosContext>>
    {
        private readonly IList<Action<VolvoxHeliosContext>> actions = new List<Action<VolvoxHeliosContext>>();

        public void Push(Action<VolvoxHeliosContext> delayedItem)
        {
            actions.Add(delayedItem);
        }

        /// <summary>
        ///     Returns an immutable clone of all added items. Afterwards clears all items added to the repository.
        /// </summary>
        /// <returns></returns>
        public IList<Action<VolvoxHeliosContext>> Get()
        {
            var readOnlyCollection = new ReadOnlyCollection<Action<VolvoxHeliosContext>>(new List<Action<VolvoxHeliosContext>>(actions));

            this.actions.Clear();

            return readOnlyCollection;
        }
    }
}