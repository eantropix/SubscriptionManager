using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IMessageBrokerAppService<T> where T : class
    {
        void Publish(T body, string routeKey = "");
    }
}
