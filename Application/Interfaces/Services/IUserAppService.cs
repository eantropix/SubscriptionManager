using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IUserAppService
    {
        void Create(User user);
        User Read(int userId);
        void Update(User user);
        void Delete(int userId);
    }
}