using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public class VolvoxHeliosActionRepository : IRepository<Action<VolvoxHeliosContext>>
    {
        private readonly IList<Action<VolvoxHeliosContext>> _actions = new List<Action<VolvoxHeliosContext>>();

        /// <summary>
        ///     Returns an immutable clone of all added items. Afterwards clears all items added to the repository.
        /// </summary>
        /// <returns></returns>
        public IList<Action<VolvoxHeliosContext>> Get()
        {
            var readOnlyCollection =
                new ReadOnlyCollection<Action<VolvoxHeliosContext>>(new List<Action<VolvoxHeliosContext>>(_actions));

            _actions.Clear();

            return readOnlyCollection;
        }

        /// <summary>
        ///     Adds an action to the list.
        /// </summary>
        /// <param name="delayedItem">Action to add.</param>
        public void Push(Action<VolvoxHeliosContext> delayedItem)
        {
            _actions.Add(delayedItem);
        }
    }
}