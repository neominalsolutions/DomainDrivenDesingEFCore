using AutoMapper;
using DomainDrivenDesingEFCore.Application.Dtos;
using DomainDrivenDesingEFCore.Application.Queries.Orders;
using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Domain.Orders.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Handlers
{
    public class ShippedOrderQueryHandler : IRequestHandler<GetShippedOrderQuery, IEnumerable<ShippedOrdersDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ShippedOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShippedOrdersDto>> Handle(GetShippedOrderQuery request, CancellationToken cancellationToken)
        {

            var spec = OrderSpec.Instance().ShippedOrders(request.FromDate, request.ToDate);

            var result = await _orderRepository.FindAsync(spec);

            // mapper kütüphanesi kullanarak order list tipini shippedOrdersDto dönüştürmem lazım.

            var response =  _mapper.Map<IEnumerable<ShippedOrdersDto>>(result);

            return await Task.FromResult(response);
        }
    }
}
