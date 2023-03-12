using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Commands
{
    public class CommandData
    {
        private string[] args;

        private string[] flags;

        private string name;

        public string[] Args
        {
            get
            {
                return args;
            }
            set
            {
                args = value;
            }
        }

        public string[] Flags
        {
            get
            {
                return flags;
            }
            set
            {
                flags = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public CommandData()
        {

        }

    }
}
