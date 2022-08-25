using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Address : ValueObject
    {


        protected Address()
        {

        }

        internal Address(string country, string city, string zipCode, string street)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException("Country required");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentNullException("City required");
            }

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentNullException("Zipcode required");
            }
            
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentNullException("Street required");
            }

            this.Country = country;
            this.City = city;
            this.ZipCode = zipCode;
            this.Street = street;
        }

        public string Country { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }

        public static Address CreateInstance(string country, string city, string zipCode, string street) {
            return new Address(country, city, zipCode, street);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return ZipCode;
            yield return Street;
        }
    }
}
