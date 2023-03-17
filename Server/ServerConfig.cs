using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace MyRPC.Server
{
    public class ServerConfig
    {
        public static string currentDirectory { get; set; }

        private string nameServer;

        private int port;

        private string ipAddress;

        public string NameServer { get; set; }

        public int Port { get; set; }
        
        public string IpAddress { get; set; }

        public ServerConfig()
        {
           
        }
    }
}
