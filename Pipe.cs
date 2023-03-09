using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public class Pipe
    {
        protected Queue<byte[]> packets;

        public event Action packetReceived;


        public Pipe()
        {
            packets = new Queue<byte[]>();
        }

        public virtual bool IsAvailable()
        {
            if (packets.Count > 0 )
            {
                return true;
            }
            return false;
        }

        public virtual void PutPacketInQueue(byte[] packet)
        {
            packets.Enqueue(packet);
            packetReceived.Invoke();
        }

        public virtual byte[] GiveEmail()
        {
            return packets.Dequeue();
        }
    }
}
