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
    public class SubscriptionConsumerAppService : MessageBrokerConsumerAppService<Subscription>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Subscription> _repository;
        private readonly IRepository<EventHistory> _eventRepository;
        private const string _createRoute = "CREATE_STATUS_RK";
        private const string _readRoute = "READ_STATUS_RK";
        private const string _updateRoute = "UPDATE_STATUS_RK";
        private const string _deleteRoute = "DELETE_STATUS_RK";
        public SubscriptionConsumerAppService(IRepository<Subscription> repository, IUnitOfWork unitOfWork, IRepository<EventHistory> eventRepository, IConnectionFactory factory) : base(factory)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _eventRepository = eventRepository;
        }
        protected override void Consume(Subscription message, string routeKey)
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
