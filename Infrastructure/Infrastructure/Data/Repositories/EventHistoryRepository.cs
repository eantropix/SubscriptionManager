using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class EventHistoryRepository : Repository<EventHistory>
    {
        public EventHistoryRepository(DbContext context) : base(context) { }
    }
}
