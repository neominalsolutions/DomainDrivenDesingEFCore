using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Dtos
{
    public class ShippedOrdersDto
    {
        public DateTime ShippedDate { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItemDto> Items { get; set; }

    }
}
