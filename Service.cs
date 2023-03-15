using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public class Service
    {
        private FactoryCommand factory;

        private Pipe pipe;

        public Service(FactoryCommand factory, Pipe pipe)
        {
            this.factory = factory;
            this.pipe = pipe;
        }

        public void Start()
        {
            this.pipe.packetReceived += PacketAvailable;
        }

        private void PacketAvailable()
        {
            byte[] packet = pipe.GiveEmail();
            string stringCommand = Encoding.UTF8.GetString(packet);
           // factory.Handler = sender;
            factory.CreateCommand(stringCommand).Execute();
            
        }

        public void Stop()
        {
            this.pipe.packetReceived -= PacketAvailable;
        }
    }
}
