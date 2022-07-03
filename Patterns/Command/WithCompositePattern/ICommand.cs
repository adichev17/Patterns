using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command.WithCompositePattern
{
    public interface ICommand
    {
        void Call();
        void Undo();
        public bool Success { get; set; }
    }
}
