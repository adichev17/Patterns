using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command.WithCompositePattern
{
    public class CompositeBankAccountCommand: List<BankAccountCommand>, ICommand
    {
        public bool Success { get; set; }
        public CompositeBankAccountCommand()
        {

        }
        public CompositeBankAccountCommand([NotNull]IEnumerable<BankAccountCommand> collection) : base(collection)
        {
        }
        public virtual void Call()
        {
            Success = true;
            ForEach(cmd =>
            {
                cmd.Call();
                Success &= cmd.Success;
            });
        }
        public virtual void Undo()
        {
            foreach (var cmd in
              ((IEnumerable<BankAccountCommand>)this).Reverse())
            {
                cmd.Undo();
            }
        }

    }
}
