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
            byte[] buffer = new byte[1024];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        public void Send(byte[] data)
        {
            stream.Write(data, 0, data.Length);
        }
    }
}
