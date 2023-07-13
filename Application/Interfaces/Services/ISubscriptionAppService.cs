using Application.DTO;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface ISubscriptionAppService
    {
        void Create(SubscriptionDTO subscriptionDTO);
        Subscription Read(int subscriptionId);
        void Update(SubscriptionDTO subscriptionDTO);
        void Delete(int subscriptionId);
    }
}
