using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.Orders.Repositories;
using DomainDrivenDesingEFCore.Domain.Orders.Services;
using DomainDrivenDesingEFCore.Domain.Orders.ValueObjects;
using DomainDrivenDesingEFCore.Domain.SeedWork;
using DomainDrivenDesingEFCore.Persistance.EFCore.Contexts;
using DomainDrivenDesingEFCore.Persistance.EFCore.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore
{
    public class Startup
    {
        //private readonly IOrderRepository _orderRepository;
        //private readonly OrderReservationService orderReservationService;



        public Startup(IConfiguration configuration)
        {
            //_orderRepository = orderRepository;

            //var s = ShipAddress.Create("Ýzmir", "Türkiye");
            //var o = Order.Create(s,"1");
            //o.AddOrderItem(quantity: 1, listPrice: 14M);
            //o.AddOrderItem(quantity: 2, listPrice: 15M);

            //o.ApplyReservation(orderReservationService);
            //o.ApplyReservation(orderReservationService);

            //_orderRepository.Add(o);
            //_orderRepository.Save();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // MediatrDomainEventDispatcher current assembly ugulamaya gösterdik.

            services.AddDbContext<OrderContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString ("TestConnection")));

            services.AddMediatR(typeof(MediatrDomainEventDispatcher).GetTypeInfo().Assembly);

            // IEventDispatcher kullanýrsam MediatrDomainEventDispatcher instance al
            services.AddTransient<IEventDispatcher, MediatrDomainEventDispatcher>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderReservationDomainService, OrderReservationService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
