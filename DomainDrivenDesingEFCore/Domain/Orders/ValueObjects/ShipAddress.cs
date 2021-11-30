using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.Orders.ValueObjects
{
    public class ShipAddress
    {
        public string City { get; private set; }
        public string Country { get; private set; }

        private ShipAddress(string city,string country)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new Exception("City giriniz");
            }

            if (string.IsNullOrEmpty(country))
            {
                throw new Exception("Country giriniz");
            }

            City = city.Trim();
            Country = country.Trim();
        }

        public static ShipAddress Create(string city, string country)
        {
            return new ShipAddress(city, country);
        }

    }
}
