using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public class VolvoxHeliosActionRepositoryProcessor : IDelayedServiceProcessor, IRepository<Action<VolvoxHeliosContext>>, IVolvoxHeliosActionRepositoryProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public VolvoxHeliosActionRepositoryProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public static IList<Action<VolvoxHeliosContext>> Actions = new List<Action<VolvoxHeliosContext>>();

        /// <summary>
        ///     Returns an immutable clone of all added items. Afterwards clears all items added to the repository.
        /// </summary>
        /// <returns></returns>
        public IList<Action<VolvoxHeliosContext>> Get()
        {
            var readOnlyCollection =
                new ReadOnlyCollection<Action<VolvoxHeliosContext>>(new List<Action<VolvoxHeliosContext>>(Actions));

            Actions.Clear();

            return readOnlyCollection;
        }

        /// <summary>
        ///     Adds an action to the list.
        /// </summary>
        /// <param name="delayedItem">Action to add.</param>
        public void Push(Action<VolvoxHeliosContext> delayedItem)
        {
            Actions.Add(delayedItem);
        }

        public async Task ProcessAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var volvoxHeliosContext = scope.ServiceProvider.GetRequiredService<VolvoxHeliosContext>();

                foreach (var action in Get())
                {
                    action.Invoke(volvoxHeliosContext);
                }

                await volvoxHeliosContext.SaveChangesAsync();
            }
        }
    }
}