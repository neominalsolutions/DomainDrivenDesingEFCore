using AutoMapper;
using DomainDrivenDesingEFCore.Application.Dtos;
using DomainDrivenDesingEFCore.Domain.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Mappers.Orders
{
    public class ShippedOrderMapper: Profile
    {
        public ShippedOrderMapper()
        {
            CreateMap<Order, ShippedOrdersDto>()
        .ForMember(dest =>
            dest.ShippedDate,
            opt => opt.MapFrom(src => src.ShippedDate))
        .ForMember(dest =>
            dest.CustomerName,
            opt => opt.MapFrom(src => src.CustomerId))
        .ForMember(dest =>
            dest.CountryName,
            opt => opt.MapFrom(src => src.ShipAddress.Country))
        .ForMember(dest =>
            dest.CityName,
            opt => opt.MapFrom(src => src.ShipAddress.City));

        }
    }
}
