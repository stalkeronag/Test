using MyRPC.Interfaces;
using MyRPC.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Commands
{
    public class HelloCommand : ICommand
    {
        public string[] Args { get; set;}
        public string[] Flags { get; set; }

        public void Execute(HandlerBytes handler)
        {
            Console.WriteLine("Hello world");
            byte[] bytes = Encoding.UTF8.GetBytes("Heheheha");
            handler.Invoke(bytes);
        }
    }
}
