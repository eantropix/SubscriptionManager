using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IUserAppService : IMessageBrokerAppService<User>
    {
        void Create(User user);
        User Read(int userId);
        void Update(User user);
        void Delete(int userId);
    }
}