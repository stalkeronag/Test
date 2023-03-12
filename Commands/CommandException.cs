using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Commands
{
    public class CommandException : Exception
    {
        public CommandException() 
        {
            
        }

        public CommandException(string message) 
            : base(message) { }
    }
}
