using Application.Interfaces.Services;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly Publisher _publisher;
        private readonly IRepository<User> _repository;
        private const string _createRoute = "CREATE_USER_RK";
        private const string _readRoute = "READ_USER_RK";
        private const string _updateRoute = "UPDATE_USER_RK";
        private const string _deleteRoute = "DELETE_USER_RK";

        public UserAppService(IRepository<User> repository, Publisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public void Create(User user)
        {
            _publisher.Publish(user, _createRoute);
        }
        
        public User Read(int userId)
        {            
            return _repository.Read(userId);
        }

        public void Update(User user)
        {
            _publisher.Publish(user, _updateRoute);
        }

        public void Delete(int userId)
        {
            _publisher.Publish( new User { Id = userId }, _deleteRoute);
        }
    }
}
