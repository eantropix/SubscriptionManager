using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
