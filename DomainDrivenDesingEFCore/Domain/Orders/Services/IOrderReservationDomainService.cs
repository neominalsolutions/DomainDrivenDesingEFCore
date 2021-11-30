using DomainDrivenDesingEFCore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Services
{
    public interface IOrderReservationDomainService: IDomainService
    {
        // bir müşteri ayda en fazla 2 adet rezervasyon yapabilir.
        void CheckReservation(string customerId);
    }
}
