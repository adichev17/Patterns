using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
    public class ResponsiblePerson
    {
        private readonly Person person;

        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }

        public string Drink()
        {
            if (Age >= 18)
                return person.Drink();
            return "too young";
        }

        public string Drive()
        {
            if (Age >= 16)
                return person.Drive();
            return "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}
