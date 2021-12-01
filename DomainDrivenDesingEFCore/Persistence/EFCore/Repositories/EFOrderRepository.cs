using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Infrastructure.Persistences.EFCore;
using DomainDrivenDesingEFCore.Persistence.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Persistence.EFCore.Repositories
{
    public class EFOrderRepository : EFBaseRepository<OrderContext, Order>, IOrderRepository
    {
        public EFOrderRepository(OrderContext context) : base(context)
        {
        }

        public override async Task<Order> FindByIdAsync(string key)
        {
           return  
                
                await Task.FromResult(_dbSet.Where(x => x.IsDeleted).FirstOrDefault(x => x.Id == key));

            //return base.FindByIdAsync(key);
        }


    }
}
