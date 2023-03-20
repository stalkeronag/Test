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

        public string Name { get; set; }


        public async Task Execute(HandlerBytes handler)
        {
            Console.WriteLine("Hello world");
            byte[] bytes = Encoding.UTF8.GetBytes("Heheheha");
            await handler.Invoke(bytes);
        }
    }
}
