using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
