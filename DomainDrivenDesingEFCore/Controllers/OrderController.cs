using DomainDrivenDesingEFCore.Application.Commands.Orders;
using DomainDrivenDesingEFCore.Application.Dtos;
using DomainDrivenDesingEFCore.Application.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Controllers
{
    public class OrderController : Controller
    {
        // InMemoryBus olarak çalışır.
        private readonly IMediator _mediator;
        //private readonly IOrderService

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var command = new OrderCreateCommand(orderCreateDto:orderCreateDto);
            // Handler Controller üzerinden çağırma şeklimiz.
            var result = await _mediator.Send(command);

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetShippedOrders(DateTime from, DateTime to)
        {
            var query = new GetShippedOrderQuery(from,to);
            // Handler Controller üzerinden çağırma şeklimiz.
            var result = await _mediator.Send(query);

            return View(result);
        }
    }
}
