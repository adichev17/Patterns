using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FlyWeight.Second_Example
{
    public class TextRange
    {
        public int Start, End;
        public bool Capitalize, Bold, Italic;

        public bool Covers(int position)
        {
            return position >= Start && position <= End;
        }
    }
}
