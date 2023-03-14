using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public abstract class FactoryCommand
    {
        protected IHandler handler;
        
        public IHandler Handler
        {
            get
            {
                return handler;
            }
            set
            {
                handler = value;
            }
        }

        public abstract ICommand CreateCommand(string commandString);
    }

}
