using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command.CommandDefault
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }
        public Action TheAction;
        public int Amount;
        public bool Success;
    }
}
