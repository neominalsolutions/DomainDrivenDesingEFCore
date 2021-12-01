using AutoMapper;
using DomainDrivenDesingEFCore.Application.Dtos;
using DomainDrivenDesingEFCore.Domain.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Mappers.Orders
{
    public class OrderItemMapper: Profile
    {

        public OrderItemMapper()
        {
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest =>
            dest.ListPrice,
            opt => opt.MapFrom(src => src.ListPrice))
                .ForMember(dest =>
            dest.Quantity,
            opt => opt.MapFrom(src => src.Quantity));
        }
    }
}
