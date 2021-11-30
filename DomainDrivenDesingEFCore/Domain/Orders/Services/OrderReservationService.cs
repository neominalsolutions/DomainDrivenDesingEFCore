using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Services
{
    public class OrderReservationService : IOrderReservationDomainService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderReservationService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Ay içerisinde en fazla 2 tane rezervasyon yapabilir.
        /// </summary>
        /// <param name="customerId"></param>
        public void CheckReservation(string customerId)
        {
          
        }
    }
}
