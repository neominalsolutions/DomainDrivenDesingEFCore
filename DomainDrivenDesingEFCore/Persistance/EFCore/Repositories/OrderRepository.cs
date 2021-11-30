using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Persistance.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Persistance.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public void Add(Order rootEntity)
        {
            _orderContext.Add(rootEntity);
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }

        public void Update(Order rootEntity)
        {
            throw new NotImplementedException();
        }
    }
}
