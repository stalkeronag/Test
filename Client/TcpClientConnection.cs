using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyRPC.Interfaces;

namespace MyRPC.Client
{
    public class TcpClientConnection : IConnection
    {
        private TcpClient client;

        private NetworkStream stream;

        private IPEndPoint remoteEndPoint;

        public TcpClientConnection(TcpClient client)
        {
            this.client = client;
        }

        public TcpClientConnection(IPEndPoint endPoint)
        {
            this.remoteEndPoint = endPoint;
            client = new TcpClient();
        }


        public void Close()
        {
            client.Close();
        }

        public void Connect()
        {
            client.Connect(remoteEndPoint);
            stream = client.GetStream();
        }

        public byte[] Read()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[1024];
                int length = stream.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer, 0, length);
                return memoryStream.ToArray();
            }
        }

        public void Send(byte[] data)
        {
            stream.Write(data, 0, data.Length);
        }
    }
}
