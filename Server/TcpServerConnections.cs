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

        public void Connect()
        {
            listener.Start();
            var client = listener.AcceptTcpClient();
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
