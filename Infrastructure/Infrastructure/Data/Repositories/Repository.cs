using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;
using SubscriptionManager.Domain.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        protected readonly DbContext _Context;

        public Repository(DbContext context)
        {
            _Context = context;
            _Context.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            _Context.Add(entity);
            return entity;
        }
        public TEntity Read(int id)
        {
            var entity = _Context.Find<TEntity>(id);
            if (entity is not null) {
                return entity;
            }
            return default;
        }
        public TEntity Update(TEntity entity)
        {
            _Context.Update(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _Context.Find<TEntity>(id);
            if (entity is not null) {
                _Context.Remove(entity);
                return true;
            }
            return false;
        }


    }
}
