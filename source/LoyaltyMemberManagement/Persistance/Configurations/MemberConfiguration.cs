using Domain.AggregatesModel.MemberAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace Persistance.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Address).IsRequired();
            builder.Property(t => t.CreatedBy)
             .HasMaxLength(100)
             .IsRequired();
            builder.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(t => t.UpdatedBy)
             .HasMaxLength(100);
            builder.Property(e => e.UpdatedDate).HasColumnType("timestamp without time zone");
        }
    }
}
