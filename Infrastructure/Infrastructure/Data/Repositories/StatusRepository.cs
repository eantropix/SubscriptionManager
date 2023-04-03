using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class StatusRepository : Repository<Status>
    {
        public StatusRepository(AppDbContext context) : base(context) { }
    }
}
