using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRPC.Server;

namespace MyRPC.Interfaces
{
    public interface ICommand
    {
        string[] Args { get; set; }

        string[] Flags { get; set; }
        public void Execute(HandlerBytes handler);

    }
}
