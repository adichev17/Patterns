using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command.WithCompositePattern
{
    public class BankAccountCommand : ICommand
    {
        private readonly BankAccount account;
        public bool Success { get; set; }
        public enum Action
        {
            Deposit, Withdraw
        }
        private readonly Action action;
        private readonly int amount;
        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }
        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    this.Success = true;
                    break;
                case Action.Withdraw:
                    this.Success = account.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void Undo()
        {
            if (!this.Success) return;
            switch (action)
            {
                case Action.Deposit:
                    account.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    account.Deposit(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
