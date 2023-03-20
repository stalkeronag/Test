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



        public async void Start()
        {
            connection.Connect();
            while(true)
            {
                try
                {
                    string stringCommand = Console.ReadLine();
                    if(String.IsNullOrEmpty(stringCommand))
                    {
                        continue;
                    }
                    byte[] bytes = Encoding.UTF8.GetBytes(stringCommand);
                    connection.Send(bytes);
                    byte[] response = await connection.Read();
                    string answer = Encoding.UTF8.GetString(response);
                    Console.WriteLine("Server response:");
                    Console.WriteLine(answer);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    connection.Connect();
                }
                
            }
           
        }

        public void Stop()
        {
            connection.Close();
        }
    }
}
