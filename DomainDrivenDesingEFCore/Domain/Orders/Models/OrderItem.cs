using DomainDrivenDesingEFCore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.Models
{
    public class OrderItem: Entity
    {
        public string Id { get; private set; }
        public int Quantity { get; private set; }
        public decimal ListPrice { get; private set; }

        // Bu nesne içerisinde direk bir bağlantı olduğu için OrderItem Order üzerinden yönetildiği için benim bu modelde OrderId alanına ihtiyacım yok

        // Program trafında olmayıp DB tarafında olan bu propertylere Shadow Property ismi veriliyor.

      

        private OrderItem(int quantity,decimal listPrice)
        {
            Id = Guid.NewGuid().ToString();
            _setQuantity(quantity);
            _setListPrice(listPrice);
        }

        public static OrderItem Create(int quantity, decimal listPrice)
        {
            return new OrderItem(quantity, listPrice);
        }


        private void _setQuantity(int quantity)
        {
            if(quantity > 100)
            {
                throw new Exception("En fazla tek seferede 100 adet ürün sipariş edilebilir");
            }

            if(quantity < 0)
            {
                throw new Exception("Adet negatif değer olamaz");
            }

            Quantity = quantity;
        }

        private void _setListPrice(decimal listPrice)
        {
            if(listPrice <= 0)
            {
                throw new Exception("Sipariş edilen ürün fiyatı 0 ve daha küçük olmaz");
            }

            ListPrice = listPrice;
        }

    }
}
