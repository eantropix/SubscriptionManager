using Domain.Models;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        public T Create(T entity);
        public T Read(int entityId);
        public T Update(T entity);
        public bool Delete(int entityId);
    }
}
