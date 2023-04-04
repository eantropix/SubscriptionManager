using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Models
{
    public class EventHistory : Entity
    {
        public int SubscriptionId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
