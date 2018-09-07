using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public class VolvoxHeliosActionRepositoryProcessor : IDelayedServiceProcessor, IRepository<Action<VolvoxHeliosContext>>, IVolvoxHeliosActionRepositoryProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMemoryCache _cache;
        private const string ActionCacheKey = "VolvoxHeliosActions";

        public VolvoxHeliosActionRepositoryProcessor(IServiceScopeFactory scopeFactory, IMemoryCache cache)
        {
            _scopeFactory = scopeFactory;
            _cache = cache;
        }

        /// <summary>
        ///     Returns an immutable clone of all added items. Afterwards clears all items added to the repository.
        /// </summary>
        /// <returns></returns>
        public IList<Action<VolvoxHeliosContext>> Get()
        {
            var readOnlyCollection =
                new ReadOnlyCollection<Action<VolvoxHeliosContext>>(
                    new List<Action<VolvoxHeliosContext>>(
                        _cache.Get<List<Action<VolvoxHeliosContext>>>(ActionCacheKey)));

            _cache.Remove(ActionCacheKey);

            return readOnlyCollection;
        }

        /// <summary>
        ///     Adds an action to the list.
        /// </summary>
        /// <param name="delayedItem">Action to add.</param>
        public void Push(Action<VolvoxHeliosContext> delayedItem)
        {
            if (!_cache.TryGetValue(ActionCacheKey, out IList<Action<VolvoxHeliosContext>> actions))
            {
                actions = new List<Action<VolvoxHeliosContext>>
                {
                    delayedItem
                };

                _cache.Set(ActionCacheKey, actions);
            }

            else
            {
                _cache.Get<IList<Action<VolvoxHeliosContext>>>(ActionCacheKey).Add(delayedItem);
            }
        }

        /// <summary>
        ///     Save changes to the database
        /// </summary>
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