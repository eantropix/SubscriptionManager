﻿using SubscriptionManager.Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IUserAppService : IMessageBrokerAppService<User>
    {
        void Create(User user);
        void Read(int userId);
        void Update(User user);
        void Delete(int userId);

    }
}