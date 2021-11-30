using DomainDrivenDesingEFCore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Events
{
    // Domain eventler bu operasyon ile ilgili Handler'a sadece veri taşımaktan sorumludurlar. Immutable olarak yazılırlar
    public class OrderReserved: IDomainEvent
    {
        // OrderId üzerinden Customer' ulaşılada biliriz.
        public string OrderId { get; private set; }


        public OrderReserved(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new Exception("OrderId boş gönderilemez");
            }

            OrderId = orderId;
        }

    }
}
