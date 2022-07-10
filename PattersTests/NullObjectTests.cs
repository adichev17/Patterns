using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Patterns.NullObject.Example;

namespace PattersTests
{
    [TestFixture]
    public class NullObjectTests
    {
        [Test]
        public void Test()
        {
            var log = new NullLog();
            var ba = new BankAccount(log);
            ba.Deposit(100);
            ba.Withdraw(200);
        }
    }
}
