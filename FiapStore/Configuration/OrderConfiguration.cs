﻿using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(o => o.ProductName).HasColumnType("VARCHAR(100)");
            builder.HasOne(o => o.User)
                        .WithMany(u => u.OrderList)
                        .HasPrincipalKey(u => u.Id)
                        .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
