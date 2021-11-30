using DomainDrivenDesingEFCore.Domain.Orders.Events;
using DomainDrivenDesingEFCore.Domain.Orders.Services;
using DomainDrivenDesingEFCore.Domain.Orders.ValueObjects;
using DomainDrivenDesingEFCore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Models
{
    public enum OrderStates
    {
        Started = 0,
        Ordered = 1,
        Reserved = 2,
        Canceled =3,
        Shipped = 4,
        Completed = 5,
        
    }

    // Root Entity
    public class Order: Entity, IAggregateRoot
    {
        public string Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime? ShippedDate { get; private set; }
        public int OrderState { get; private set; }

        public string CustomerId { get; private set; }

    

        // orderItemların Order Aggregate tanımlanmasını field üzerinden yöneticem
        private List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public ShipAddress ShipAddress { get; private set; }

        /// <summary>
        /// AggregateRoot için Repository işlemlerinde private boş constructor kullandık.
        /// </summary>
        private Order()
        {

        }

        private Order(ShipAddress shipAddress, string customerId)
        {
            if(shipAddress == default(ShipAddress))
            {
                throw new Exception("Address değerini giriniz");
            }

            if (string.IsNullOrEmpty(customerId))
            {
                throw new Exception("Müşteri bilgisi girilmelidir.");
            }

            Id = Guid.NewGuid().ToString();
            CustomerId = customerId;
            ShipAddress = shipAddress;
            OrderDate = DateTime.Now;
            OrderState = (int)OrderStates.Started;

            
        }

        public static Order Create(ShipAddress shipAddress,string customerId)
        {
            return new Order(shipAddress, customerId);
        }


        public void AddOrderItem(int quantity, decimal listPrice)
        {
            // Eğer ki Order Nesnesine tek seferde 10 adetten fazla ürün sipariş edilirse hata fırlatsın

            if(_orderItems.Count > 10)
            {
                throw new Exception("Tek seferede 10 adet farklı ürün sipariş edilebilir");
            }

            _orderItems.Add(OrderItem.Create(quantity, listPrice));

         

            // Order
        }

        public void ApplyReservation(IOrderReservationDomainService dService)
        {

            // Completed,Shipped ve Canceled olmaması lazım
            //if(OrderState < (int)OrderStates.Ordered)
            //{
            //    throw new Exception("Bu sipariş rezerve edilemez");
            //}

            dService.CheckReservation(customerId:CustomerId);

            OrderState = (int)OrderStates.Reserved;

            var @event = new OrderReserved(Id);
            AddEvent(@event);
        }


    }
}
