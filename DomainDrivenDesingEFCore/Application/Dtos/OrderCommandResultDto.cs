using DomainDrivenDesingEFCore.Domain.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Dtos
{
    public class OrderCommandResultDto
    {
        public string OrderId { get; set; }
        public string OrderState { get; set; }
    }
}
