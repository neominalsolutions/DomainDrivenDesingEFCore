using DomainDrivenDesingEFCore.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Queries.Orders
{
    public class GetShippedOrderQuery: IRequest<IEnumerable<ShippedOrdersDto>>
    {
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }


        public GetShippedOrderQuery(DateTime shippedFromDate, DateTime shippedToDate)
        {
            FromDate = shippedFromDate;
            ToDate = shippedToDate;
        }
    }
}
