using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Dtos
{
    public class OrderItemDto
    {
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
    }

    public class OrderCreateDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }


    }
}
