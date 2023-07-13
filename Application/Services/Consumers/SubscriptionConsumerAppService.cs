using Domain.Models;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Application.DTO;
using Application.Interfaces.Services;

namespace Application.Services.Consumers
{
    public class SubscriptionConsumerAppService : MessageBrokerConsumerAppService<Subscription>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Subscription> _repository;
        private readonly IRepository<EventHistory> _eventRepository;
        private readonly IEventHistoryAppService _eventHistoryAppService;
        private const string _createRoute = "CREATE_SUBSCRIPTION_RK";
        private const string _readRoute = "READ_SUBSCRIPTION_RK";
        private const string _updateRoute = "UPDATE_SUBSCRIPTION_RK";
        private const string _deleteRoute = "DELETE_SUBSCRIPTION_RK";
        public SubscriptionConsumerAppService(IEventHistoryAppService eventHistoryAppService, IRepository<Subscription> repository, IUnitOfWork unitOfWork, IRepository<EventHistory> eventRepository, IConnectionFactory factory) : base(factory)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _eventRepository = eventRepository;
            _eventHistoryAppService = eventHistoryAppService;
        }
        protected override void Consume(Subscription message, string routeKey)
        {
            Subscription subscription;
            string type = "";
            bool success;
            switch (routeKey) {
                case _createRoute:
                    subscription = _repository.Create(message);
                    success = _unitOfWork.Commit();
                    if (success) {
                        _eventHistoryAppService.Create(subscription.Id, "CREATE");
                    }
                    break;
                case _updateRoute:
                    subscription = _repository.Update(message);
                    success = _unitOfWork.Commit();
                    if (success) {
                        _eventHistoryAppService.Create(subscription.Id, "UPDATE");
                    }
                    break;
                case _deleteRoute:
                    success = _repository.Delete(message.Id);
                    if (success) {
                        _eventHistoryAppService.Create(message.Id, "DELETE");
                    }
                    break;
            }
        }
    }
}
