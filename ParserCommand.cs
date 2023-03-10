using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public class ParserCommand : IParser
    {
        private ICommand command;
        public object obj { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Parse(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
