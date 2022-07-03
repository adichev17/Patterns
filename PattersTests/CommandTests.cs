using NUnit.Framework;
using Patterns.Command.CommandDefault;
using Patterns.Command.WithCompositePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattersTests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Command_CommandDefault_Test()
        {
            var a = new Account();

            var command = new Command { Amount = 100, TheAction = Command.Action.Deposit };
            a.Process(command);

            Assert.That(a.Balance, Is.EqualTo(100));
            Assert.IsTrue(command.Success);

            command = new Command { Amount = 50, TheAction = Command.Action.Withdraw };
            a.Process(command);

            Assert.That(a.Balance, Is.EqualTo(50));
            Assert.IsTrue(command.Success);

            command = new Command { Amount = 150, TheAction = Command.Action.Withdraw };
            a.Process(command);

            Assert.That(a.Balance, Is.EqualTo(50));
            Assert.IsFalse(command.Success);
        }

        [Test]
        public void Command_WithComposite_Test()
        {
            var ba = new BankAccount();
            var cmdDeposit = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
            var cmdWithdraw = new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000);
            var composite = new CompositeBankAccountCommand(new[]
            {
                cmdDeposit,
                cmdWithdraw
            });

            composite.Call();


            Assert.NotNull(composite);
            //First Command - cmdDeposit
            Assert.IsTrue(composite[0].Success);
            //SecondCommand - cmdWithdraw
            Assert.IsFalse(composite[1].Success);
        }
        [Test]
        public void Command_MoneyTransfer_Test()
        {
            var from = new BankAccount();
            from.Deposit(100);
            var to = new BankAccount();

            var mtc = new MoneyTransferCommand(from, to, 1000);
            mtc.Call();
            mtc.Undo();

            Assert.That(mtc.Capacity, Is.EqualTo(4));
            Assert.IsFalse(mtc.Success);
        }
    }
}
