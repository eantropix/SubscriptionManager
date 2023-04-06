using Application.Interfaces.Services;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubscriptionAppService : MessageBrokerAppService<Subscription>, ISubscriptionAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Subscription> _repository;
        private readonly IRepository<EventHistory> _eventRepository;
        private const string _createRoute = "CREATE_SUBSCRIPTION_RK";
        private const string _readRoute = "READ_SUBSCRIPTION_RK";
        private const string _updateRoute = "UPDATE_SUBSCRIPTION_RK";
        private const string _deleteRoute = "DELETE_SUBSCRIPTION_RK";

        public SubscriptionAppService(IRepository<Subscription> repository, IUnitOfWork unitOfWork, IRepository<EventHistory> eventRepository) : base("subscriptionQueue")
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _eventRepository = eventRepository;
        }

        protected override void Consume(Subscription message, string routeKey)
        {
            switch (routeKey) {
                case _createRoute:
                    _repository.Create(message);
                    _eventRepository.Create(new EventHistory { 
                        Subscription = message, 
                        SubscriptionId = message.Id, 
                        Type = message.Status.StatusName, 
                        CreatedAt = message.CreatedAt });
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

        public void Create(Subscription subscription)
        {
            Publish(subscription, _createRoute);
        }
        
        public void Read(int subscriptionId)
        {
            Publish(subscriptionId, _readRoute);
        }

        public void Update(Subscription subscription)
        {
            Publish(subscription, _updateRoute);
        }

        public void Delete(int subscriptionId)
        {
            Publish(subscriptionId, _deleteRoute);
        }
    }
}
