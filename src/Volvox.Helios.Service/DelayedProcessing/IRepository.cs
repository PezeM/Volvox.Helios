using System.Collections.Generic;

namespace Volvox.Helios.Service.DelayedProcessing
{
    public interface IRepository<T>
    {
        IList<T> Get();
    }
}