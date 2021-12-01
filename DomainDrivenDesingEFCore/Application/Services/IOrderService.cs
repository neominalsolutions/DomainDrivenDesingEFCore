using DomainDrivenDesingEFCore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Application.Services
{
    public interface IOrderService
    {
        void CreateOrder(OrderCreateDto orderCreateDto);
    }
}
