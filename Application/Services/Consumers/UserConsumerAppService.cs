using Domain.Models;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Application.Services.Consumers
{
    public class UserConsumerAppService : MessageBrokerConsumerAppService<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _repository;
        private readonly IRepository<EventHistory> _eventRepository;
        private const string _createRoute = "CREATE_USER_RK";
        private const string _readRoute = "READ_USER_RK";
        private const string _updateRoute = "UPDATE_USER_RK";
        private const string _deleteRoute = "DELETE_USER_RK";
        public UserConsumerAppService(IRepository<User> repository, IUnitOfWork unitOfWork, IRepository<EventHistory> eventRepository, IConnectionFactory factory) : base(factory)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _eventRepository = eventRepository;
        }
        protected override void Consume(User message, string routeKey)
        {
            switch (routeKey)
            {
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
    }

}
