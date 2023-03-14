using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public interface ICommand
    {
        string[] Args { get; set; }

        string[] Flags { get; set; }

        public IHandler handler { get; set; }

        public void Execute();

    }
}
