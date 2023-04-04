using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IStatusAppService
    {
        void Create(Status status);
        void Read(int statusId);
        void Update(Status status);
        void Delete(int statusId);
    }
}
