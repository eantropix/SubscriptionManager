using SubscriptionManager.Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IUserAppService : IMessageBrokerAppService<User>
    {
        void Create(User user);
    }
}