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
        string Name { get; set; }

        string[] Args { get; set; }


        string[] Flags { get; set; }


        public Task Execute(HandlerBytes handler);

    }
}
