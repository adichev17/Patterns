using NUnit.Framework;
using Patterns.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattersTests
{
    [TestFixture]
    public class State
    {
        [Test]
        public void Test()
        {
            //Look code inside class
            var stateless = new StatelessLightSwitch();
        }
    }
}
