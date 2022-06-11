﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype.PrototypeWithCtorCopy
{
    public class Employee
    {
        public string Name;
        public Address Address;
        public Employee(string name, Address address)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }
        public Employee(Employee other)
        {
            Name = other.Name;
            Address = new Address(other.Address);
        }
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
