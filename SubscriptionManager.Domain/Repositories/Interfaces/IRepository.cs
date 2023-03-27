using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        public T Create(T entity);
        public T Read(int entityId);
        public T Update(T entity);
        public bool Delete(int entityId);
    }
}
