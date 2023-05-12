using Infrastructure.Data.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context {
    public class AppDbContext : DbContext {
        public DbSet<EventHistory> EventHistory { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<User> User { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventHistoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

    }
}
