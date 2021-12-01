using DomainDrivenDesingEFCore.Application.Dtos;
using DomainDrivenDesingEFCore.Domain.Orders.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Commands.Orders
{
    public class OrderCreateCommand:IRequest<OrderCommandResultDto>
    {
        public OrderCreateDto OrderDto { get; private set; }

        public OrderCreateCommand(OrderCreateDto orderCreateDto)
        {
            OrderDto = orderCreateDto;
        }
    }
}
