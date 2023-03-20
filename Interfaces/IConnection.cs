using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Interfaces
{
    public interface IConnection
    {
        public void Close();

        public Task Connect();

        public Task Send(byte[] data);

        public Task<byte[]> Read();

    }
}
