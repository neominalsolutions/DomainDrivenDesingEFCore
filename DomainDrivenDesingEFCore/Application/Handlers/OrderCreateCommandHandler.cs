using DomainDrivenDesingEFCore.Application.Commands.Orders;
using DomainDrivenDesingEFCore.Application.Dtos;
using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Domain.Orders.Specs;
using DomainDrivenDesingEFCore.Domain.Orders.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Handlers
{
    // Uygulama katmanından gelen bir iş istediğinin koordinasyonundan sorumludur.
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, OrderCommandResultDto>
    {
        private readonly IOrderRepository _orderRepository;
        //private readonly IMessageBus _bus;

        public OrderCreateCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderCommandResultDto> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            

            var s = ShipAddress.Create(request.OrderDto.City,request.OrderDto.Country);
            var o = Order.Create(s, request.OrderDto.CustomerId);


            await _orderRepository.FindAsync(x => x.OrderState == (int)OrderStates.Ordered);
            var orderSpec = OrderSpec.Instance().OrderFilterCustomer("1");
            await _orderRepository.FindAsync(orderSpec);


            foreach (var item in request.OrderDto.OrderItems)
            {
                o.AddOrderItem(quantity: item.Quantity, listPrice: item.ListPrice);
                await _orderRepository.AddAsync(o);
            }


            await _orderRepository.SaveAsync();

            // burada diğer micorservislere haber verecek olan RabitMq Bus Service üzerinden bir mesaj gönderebiliriz.

            var response = new OrderCommandResultDto()
            {
                OrderId = o.Id,
                OrderState = o.OrderState.ToString()
            };

            //await _bus.Publish(response);


            return await Task.FromResult(response);

            
        }
    }
}
