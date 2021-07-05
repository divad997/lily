using Internship.Core;
using Internship.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Internship.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Context context
        {
            get { return _context as Context; }
        }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}