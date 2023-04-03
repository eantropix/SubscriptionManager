using Application.Interfaces.Services;
using Domain.Repositories.Interfaces.UnitOfWork;
using SubscriptionManager.Domain.Models;
using SubscriptionManager.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public UserAppService(IRepository<User> repository, IUnitOfWork unitOfWork) : base("usersQueue")
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
                case _readRoute:
                    _repository.Read(message.Id);
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
        
        public void Read(int userId)
        {
            Publish(userId, _readRoute);
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
