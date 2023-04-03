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
    public class StatusEntityConfiguration : IEntityTypeConfiguration<Status>
    {
        public StatusEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.StatusName).IsRequired().HasMaxLength(50);
        }
    }
}
