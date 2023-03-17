using MyRPC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Client
{
    public class ServiceClient : IService
    {
        private IConnection connection;

        public ServiceClient(IConnection connection)
        {
            this.connection = connection;
        }



        public void Start()
        {
            connection.Connect();
            while(true)
            {
                string stringCommand = Console.ReadLine();
                byte[] bytes= Encoding.UTF8.GetBytes(stringCommand);
                connection.Send(bytes);
                byte[] response = connection.Read();
                string answer = Encoding.UTF8.GetString(response);
                Console.WriteLine(answer);
            }
           
        }

        public void Stop()
        {
            connection.Close();
        }
    }
}
