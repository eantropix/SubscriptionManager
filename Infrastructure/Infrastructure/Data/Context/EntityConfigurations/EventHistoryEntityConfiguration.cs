using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context.EntityConfigurations
{
    public class EventHistoryEntityConfiguration : IEntityTypeConfiguration<EventHistory>
    {
        public EventHistoryEntityConfiguration()
        {
            
        }

        public void Configure(EntityTypeBuilder<EventHistory> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.SubscriptionId).IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
