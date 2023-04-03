using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class SubscriptionRepository : Repository<Subscription>
    {
        public SubscriptionRepository(AppDbContext context) : base(context) { }
    }
}
