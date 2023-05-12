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
    public class StatusAppService : IStatusAppService
    {
        private readonly Publisher _publisher;
        private readonly IRepository<Status> _repository;

        private const string _createRoute = "CREATE_STATUS_RK";
        private const string _readRoute = "READ_STATUS_RK";
        private const string _updateRoute = "UPDATE_STATUS_RK";
        private const string _deleteRoute = "DELETE_STATUS_RK";

        public StatusAppService(IRepository<Status> repository, Publisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public void Create(Status status)
        {
            _publisher.Publish(status, _createRoute);
        }
        
        public Status Read(int statusId)
        {
            return _repository.Read(statusId);
        }

        public void Update(Status status)
        {
            _publisher.Publish(status, _updateRoute);
        }

        public void Delete(int statusId)
        {
            _publisher.Publish(new Status { Id = statusId } , _deleteRoute);
        }
    }
}
