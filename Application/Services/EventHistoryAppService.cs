using Application.Interfaces.Services;
using Domain.Models;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventHistoryAppService : IEventHistoryAppService
    {
        private readonly Publisher _publisher;
        private readonly IRepository<EventHistory> _repository;

        private const string _createRoute = "CREATE_EVENT_HISTORY_RK";
        private const string _readRoute = "READ_EVENT_HISTORY_RK";

        public EventHistoryAppService(IRepository<EventHistory> repository, Publisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }
        public void Create(int subscriptionId, string type)
        {
            var entityHistory = new EventHistory {
                SubscriptionId = subscriptionId,
                Type = type,
                CreatedAt = DateTime.Now
            };
            _publisher.Publish(entityHistory, _createRoute);
        }

        public EventHistory Read(int eventHistoryId)
        {
            return _repository.Read(eventHistoryId);
        }
    }
}
