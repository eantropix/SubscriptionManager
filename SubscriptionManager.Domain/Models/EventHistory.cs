﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Models
{
    public class EventHistory
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
