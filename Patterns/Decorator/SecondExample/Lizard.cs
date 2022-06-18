using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator.SecondExample
{
    public class Lizard: ILizard
    {
        public int Age { get; set; }
        public string Crawl()
        {
            if (Age < 10)
                return ("I am crawling!");
            return String.Empty;
        }
    }
}
