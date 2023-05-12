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
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly Publisher _publisher;
        private readonly IRepository<Subscription> _repository;

        public SubscriptionAppService(IRepository<Subscription> repository, Publisher publisher)
        {
            _publisher = publisher;
            _repository = repository;
        }

        private const string _createRoute = "CREATE_SUBSCRIPTION_RK";
        private const string _readRoute  = "READ_SUBSCRIPTION_RK";
        private const string _updateRoute = "UPDATE_SUBSCRIPTION_RK";
        private const string _deleteRoute = "DELETE_SUBSCRIPTION_RK";

        public SubscriptionAppService() { }

        public void Create(Subscription subscription)
        {
            _publisher.Publish(subscription, _createRoute);
        }
        
        public Subscription Read(int subscriptionId)
        {
            return _repository.Read(subscriptionId);
        }

        public void Update(Subscription subscription)
        {
            _publisher.Publish(subscription, _updateRoute);
        }

        public void Delete(int subscriptionId)
        {
            _publisher.Publish(new Subscription { Id = subscriptionId }, _deleteRoute);
        }
    }
}
