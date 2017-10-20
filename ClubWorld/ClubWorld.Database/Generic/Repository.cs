using ClubWorld.Database.EntityModel;
using ClubWorld.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repository
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext Context)
        {
            context = Context;
        }
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public int Top(Expression<Func<TEntity, int>> predicate)
        {
            return context.Set<TEntity>().Max(predicate);
        }
        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
        public void ExecInsertOrUpdateSP(string spName, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand("EXEC " + spName, parameters);
        }
    }
}
