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
    public class StatusAppService : MessageBrokerAppService<Status>, IStatusAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Status> _repository;
        private const string _createRoute = "CREATE_STATUS_RK";
        private const string _readRoute = "READ_STATUS_RK";
        private const string _updateRoute = "UPDATE_STATUS_RK";
        private const string _deleteRoute = "DELETE_STATUS_RK";

        public StatusAppService(IRepository<Status> repository, IUnitOfWork unitOfWork) : base("statusQueue")
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        protected override void Consume(Status message, string routeKey)
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

        public void Create(Status status)
        {
            Publish(status, _createRoute);
        }
        
        public void Read(int statusId)
        {
            Publish(statusId, _readRoute);
        }

        public void Update(Status status)
        {
            Publish(status, _updateRoute);
        }

        public void Delete(int statusId)
        {
            Publish(statusId, _deleteRoute);
        }
    }
}
