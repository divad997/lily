using System.Collections.Generic;

namespace Internship.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}