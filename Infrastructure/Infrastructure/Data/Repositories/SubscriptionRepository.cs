using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class SubscriptionRepository : Repository<Subscription>
    {
        public SubscriptionRepository(DbContext context) : base(context) { }
    }
}
