using Application.Interfaces.Services;
using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAppService : IUserAppService
    {
        public UserAppService()
        {
            
        }

        public Task CreateUser(User user) {
            throw new NotImplementedException();
        }

        public int ReturnZero() { return 0; }
    }
}
