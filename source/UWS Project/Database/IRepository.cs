using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UWS_Project.Database
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        ValueTask<TEntity> FindById(int id);
        Task<List<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}