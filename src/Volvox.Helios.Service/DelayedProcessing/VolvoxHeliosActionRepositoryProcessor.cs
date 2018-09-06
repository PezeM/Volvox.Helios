using System;
using System.Threading.Tasks;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public class VolvoxHeliosActionRepositoryProcessor : IDelayedServiceProcessor
    {
        private readonly VolvoxHeliosContext _volvoxHeliosContext;
        private readonly IRepository<Action<VolvoxHeliosContext>> _repository;

        public VolvoxHeliosActionRepositoryProcessor(VolvoxHeliosContext volvoxHeliosContext, IRepository<Action<VolvoxHeliosContext>> repository)
        {
            _volvoxHeliosContext = volvoxHeliosContext;
            _repository = repository;
        }

        public async Task ProcessAsync()
        {
            foreach (var action in _repository.Get())
            {
                action.Invoke(_volvoxHeliosContext);
            }

            await _volvoxHeliosContext.SaveChangesAsync();
        }
    }
}