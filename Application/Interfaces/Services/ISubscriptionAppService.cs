using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface ISubscriptionAppService
    {
        void Create(Subscription subscription);
        void Read(int subscriptionId);
        void Update(Subscription subscription);
        void Delete(int subscriptionId);
    }
}
