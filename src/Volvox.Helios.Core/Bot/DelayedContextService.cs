using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volvox.Helios.Service;

namespace Volvox.Helios.Core.Bot
{
    public class DelayedContextService : IDelayedService<Action<VolvoxHeliosContext>>
    {
        private readonly VolvoxHeliosContext volvoxHeliosContext;

        private readonly IList<Action<VolvoxHeliosContext>> actions = new List<Action<VolvoxHeliosContext>>();

        public DelayedContextService(VolvoxHeliosContext volvoxHeliosContext)
        {
            this.volvoxHeliosContext = volvoxHeliosContext;
        }

        public void Push(Action<VolvoxHeliosContext> delayedItem)
        {
            actions.Add(delayedItem);
        }

        public async Task ProcessAsync()
        {
            foreach (var action in actions)
            {
                action.Invoke(volvoxHeliosContext);
            }

            await volvoxHeliosContext.SaveChangesAsync();
            actions.Clear();
        }
    }
}