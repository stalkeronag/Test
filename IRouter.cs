using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public interface IRouter
    {
        public event Action<int> OnRouteFind;
        public int Route(byte[] packet);
    }
}
