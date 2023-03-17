using MyRPC.Interfaces;
using MyRPC.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Commands
{
    public class CommandChangeDirectory : ICommand
    {
        public string[] Args { get; set; }
        public string[] Flags { get; set; }

        public void Execute(HandlerBytes handler)
        {
            if(Args.Length == 0)
            {
                throw new CommandException("this command must have one args");
            }
            string path = Args[0];
            string combinePath = Path.Combine(ServerConfig.currentDirectory, path);
            string result = "this directory not found";
            if (Directory.Exists(combinePath))
            {
                ServerConfig.currentDirectory = combinePath;
                result = "directory found:"  +  combinePath;
            }
            else
            {
                if(Directory.Exists(path))
                {
                    ServerConfig.currentDirectory = path;
                    result ="directory found:" + path;
                }
            }
            byte[] resultInBytes = Encoding.UTF8.GetBytes(result);
            handler.Invoke(resultInBytes);
            Console.WriteLine(result);
        }
    }
}
