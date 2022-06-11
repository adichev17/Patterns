using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype.PrototypeWithCtorCopy
{
    public class Address
    {
        public string StreetAddress, City;
        public int Suite;
        public Address(string streetAddress, string city, int suite)
        {
            StreetAddress = streetAddress;
            City = city;
            Suite = suite;
        }
        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Suite = other.Suite;
        }
    }
}
