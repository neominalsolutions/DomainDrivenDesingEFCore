using DomainDrivenDesingEFCore.Domain.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Persistance.EFCore.Configurations
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            // tek taraflı bir ilişkisi söz konusu OrderItemdan Order'a ulaşmamamız gerekiyor.
            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            // valueObject bağlantısı

            builder.OwnsOne(x => x.ShipAddress)
              .Property(x => x.City)
              .HasColumnName("City")
              .IsRequired();

            builder.OwnsOne(x => x.ShipAddress)
            .Property(x => x.Country)
            .HasColumnName("Country")
            .IsRequired();


        }
    }
}
