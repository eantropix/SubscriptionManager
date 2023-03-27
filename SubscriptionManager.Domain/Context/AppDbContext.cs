using Domain.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context {
    public class AppDbContext : DbContext {
        public DbSet<Status> EventHistory { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Status> Subscription { get; set; }
        public DbSet<Status> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StatusEntityConfiguration());
        }

    }
}
