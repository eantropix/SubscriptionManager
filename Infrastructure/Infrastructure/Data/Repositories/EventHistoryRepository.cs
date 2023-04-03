using Infrastructure.Data.Context;
using SubscriptionManager.Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class EventHistoryRepository : Repository<EventHistory>
    {
        public EventHistoryRepository(AppDbContext context) : base(context) { }
    }
}
