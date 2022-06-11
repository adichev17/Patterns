using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Factory
{
    public class SecondPerson
    {
        private int _age;
        private string _name;

        private SecondPerson(string name, int age)
        {
            _name = name;
            _age = age;
        }
        public static SecondPerson InitPerson(string name, int age)
        {
            return new SecondPerson(name, age);
        }
    }
}
