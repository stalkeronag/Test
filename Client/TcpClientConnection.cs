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
           
        }


        public void Close()
        {
            client.Close();
        }

        public void Connect()
        {
            try
            {
                client = new TcpClient();
                client.Connect(remoteEndPoint);
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
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
