using Application.Interfaces.Services;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.UnitOfWork;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Consumers
{
    public class EventHistoryConsumerAppService : MessageBrokerConsumerAppService<EventHistory>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EventHistory> _repository;
        private const string _createRoute = "CREATE_EVENT_HISTORY_RK";
        private const string _readRoute = "READ_EVENT_HISTORY_RK";

        public EventHistoryConsumerAppService(IRepository<EventHistory> repository, IUnitOfWork unitOfWork, IConnectionFactory factory) : base(factory)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        protected override void Consume(EventHistory message, string routeKey)
        {
            switch (routeKey) {
                case _createRoute:
                    _repository.Create(message);
                    break;   
            }
            _unitOfWork.Commit();
        }
    }
}
