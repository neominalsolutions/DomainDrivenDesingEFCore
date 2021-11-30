using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Repositories
{
    // IOrderRepository bu interface üzerinden yönetecek
    public interface IOrderRepository: IRepository<Order>
    {
    }
}
