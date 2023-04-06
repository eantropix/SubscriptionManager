using Application.Interfaces.Services;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Application.Services
{
    public class UserAppService : MessageBrokerAppService<User>, IUserAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _repository;
        private const string _createRoute = "CREATE_USER_RK";
        private const string _readRoute = "READ_USER_RK";
        private const string _updateRoute = "UPDATE_USER_RK";
        private const string _deleteRoute = "DELETE_USER_RK";

        public UserAppService(IRepository<User> repository, IUnitOfWork unitOfWork) : base("userQueue")
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        protected override void Consume(User message, string routeKey)
        {
            switch (routeKey) {
                case _createRoute:
                    _repository.Create(message);
                    break;
                case _updateRoute:
                    _repository.Update(message);
                    break;
                case _deleteRoute:
                    _repository.Delete(message.Id);
                    break;
            }
            _unitOfWork.Commit();
        }

        public void Create(User user)
        {
            Publish(user, _createRoute);
        }
        
        public User Read(int userId)
        {            
            return _repository.Read(userId);
        }

        public void Update(User user)
        {
            Publish(user, _updateRoute);
        }

        public void Delete(int userId)
        {
            Publish(userId, _deleteRoute);
        }
    }
}
