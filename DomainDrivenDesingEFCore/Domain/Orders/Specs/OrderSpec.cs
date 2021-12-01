using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Specs
{
    // Spec dosyaları singelton olmasın lütfen
    public class OrderSpec: BaseSpecification<Order>
    {
        private OrderSpec()
        {
            // Order ile birlite OrderItems Include olsun
            AddInclude(x => x.OrderItems);
            ApplyOrderBy(x => x.OrderDate);
            AddCriteria(x => x.OrderState == (int)OrderStates.Completed);
        }

        public OrderSpec OrderPaging(int limit, int offset)
        {
            ApplyPaging(offset, limit);
            return this;
        }


        public OrderSpec OrderFilterCustomer(string customerId)
        {
            AddCriteria(x => x.CustomerId == customerId);
            return this;
        }



        public static OrderSpec Instance()
        {
            return new OrderSpec();
        }

    }
}
