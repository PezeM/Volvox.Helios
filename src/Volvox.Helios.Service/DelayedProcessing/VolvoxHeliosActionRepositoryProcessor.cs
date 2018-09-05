using System;
using System.Threading.Tasks;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public class VolvoxHeliosActionRepositoryProcessor : IDelayedServiceProcessor<Action<VolvoxHeliosContext>>
    {
        private readonly VolvoxHeliosContext volvoxHeliosContext;
        private readonly IRepository<Action<VolvoxHeliosContext>> repository;

        public VolvoxHeliosActionRepositoryProcessor(VolvoxHeliosContext volvoxHeliosContext, IRepository<Action<VolvoxHeliosContext>> repository)
        {
            this.volvoxHeliosContext = volvoxHeliosContext;
            this.repository = repository;
        }

        public async Task ProcessAsync()
        {
            foreach (var action in repository.Get())
            {
                action.Invoke(volvoxHeliosContext);
            }

            await volvoxHeliosContext.SaveChangesAsync();
        }
    }
}