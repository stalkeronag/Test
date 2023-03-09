using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public class Router : IRouter
    {
        private Pipe pipeline;

        public event Action<int> OnRouteFind;

        public Router(Pipe pipe)
        {
            pipeline = pipe;
            pipe.packetReceived += PacketIsAvailable;
        }

        private void PacketIsAvailable()
        {
            if(pipeline.IsAvailable())
            {
                byte[] packet = pipeline.GiveEmail();
                Route(packet);
            }
        }

        public int Route(byte[] packet)
        {
            //ToDo realize find code executor
            int result = 0;
            OnRouteFind.Invoke(result);
            throw new NotImplementedException();
           
        }
    }
}
