using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertisementService.Interfaces
{
    public interface IRepository<TEntity>
    {
        IReadOnlyCollection<TEntity> GetEntities();
        void SaveEntities();
    }
}
