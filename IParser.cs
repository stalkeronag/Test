using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public interface IParser
    {
        public object obj { get; set; }
        public object Parse(byte[] data); 
    }
}
