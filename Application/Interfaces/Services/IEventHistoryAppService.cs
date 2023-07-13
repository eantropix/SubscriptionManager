using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IEventHistoryAppService
    {
        void Create(int subscriptionId, string type);
        EventHistory Read(int eventHistoryId);
        //void Update(EventHistory eventHistory);
        //void Delete(int eventHistoryId);

    }
}
