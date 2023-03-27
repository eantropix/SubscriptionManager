﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Models
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
