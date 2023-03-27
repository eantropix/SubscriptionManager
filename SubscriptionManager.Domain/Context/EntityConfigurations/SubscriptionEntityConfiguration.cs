using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context.EntityConfigurations
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public SubscriptionEntityConfiguration() { }

        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
