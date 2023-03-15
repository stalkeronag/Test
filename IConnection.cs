using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public interface IConnection
    {
        public void Close();

        public void Connect();

        public void Send(byte[] data);

        public byte[] Read();

    }
}
