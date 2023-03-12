using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public abstract class FactoryCommand
    {
        public abstract ICommand CreateCommand(string command_string);
    }

}
