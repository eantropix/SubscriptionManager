using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        protected readonly AppDbContext _Context;

        public Repository(AppDbContext context)
        {
            _Context = context;
            _Context.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            if (entity.Id != 0) {
                throw new InvalidOperationException("Cannot create with specified ID");
            }
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
