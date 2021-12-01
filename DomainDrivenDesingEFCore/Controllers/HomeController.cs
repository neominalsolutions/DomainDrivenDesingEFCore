using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Domain.Orders.Services;
using DomainDrivenDesingEFCore.Domain.Orders.Specs;
using DomainDrivenDesingEFCore.Domain.Orders.ValueObjects;
using DomainDrivenDesingEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderReservationDomainService _oR;

        public HomeController(ILogger<HomeController> logger, IOrderRepository orderRepository, IOrderReservationDomainService oR)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _oR = oR;
        }

        public async Task<IActionResult> Index()
        {



            var s = ShipAddress.Create("İzmir", "Türkiye");
            var o = Order.Create(s, "1");

          

            await _orderRepository.FindAsync(x => x.OrderState == (int)OrderStates.Ordered);
            var orderSpec = OrderSpec.Instance().OrderFilterCustomer("1");
            await _orderRepository.FindAsync(orderSpec);


            o.AddOrderItem(quantity: 1, listPrice: 14M);
            o.AddOrderItem(quantity: 2, listPrice: 15M);
             await _orderRepository.AddAsync(o);

            o.ApplyReservation(_oR);


            await _orderRepository.SaveAsync();





            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
