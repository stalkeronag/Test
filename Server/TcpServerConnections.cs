using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyRPC.Interfaces;

namespace MyRPC.Server
{
    public class TcpServerConnections : IConnection
    {
        private TcpListener listener;

        private int port;

        private IPAddress address;

        private NetworkStream stream;

        public TcpServerConnections(TcpListener listener)
        {
            this.listener = listener;

        }

        public TcpServerConnections(IPAddress address , int port)
        {
            this.address = address; 
            this.port = port;
            listener = new TcpListener(address, port);
        }

        public TcpServerConnections(IPEndPoint endPoint)
        {
            this.port=endPoint.Port;
            this.address = endPoint.Address;
            listener = new TcpListener(endPoint);

        }

        public void Close()
        {
            listener.Stop();
        }

        public async Task Connect()
        {
            listener.Start();
            var client = await listener.AcceptTcpClientAsync();
            stream = client.GetStream(); 
        }

        public async Task<byte[]> Read()
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[65500];
                int length = await stream.ReadAsync(buffer);
                memoryStream.Write(buffer, 0, length);
                while (stream.DataAvailable)
                {
                    length = await stream.ReadAsync(buffer);
                    memoryStream.Write(buffer, 0, length);
                }
                return memoryStream.ToArray();
            }

        }

        public async Task Send(byte[] data)
        {
            await stream.WriteAsync(data);
        }
    }
}
