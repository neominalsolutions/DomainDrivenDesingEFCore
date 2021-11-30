using DomainDrivenDesingEFCore.Domain.Orders.Events;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Handlers
{
    public class OrderReservedHandler : INotificationHandler<DomainEventNotification<OrderReserved>>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderReservedHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // IOrderRepoya Bağlan
        // IEmailSender Interface kullan
        // ILogger ile loglama yap
        public Task Handle(DomainEventNotification<OrderReserved> notification, CancellationToken cancellationToken)
        {

            string orderId = notification.DomainEvent.OrderId;
            // orderId müşteri bilgisini bulduk mail attık vs..


            return Task.CompletedTask;
            // event execute olduktan sonra yapılacak olan işlemler.
        }
    }
}
