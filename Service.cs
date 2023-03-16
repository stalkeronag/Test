using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public delegate void HandlerBytes(byte[] data);

    public class Service
    {
        private FactoryCommand factory;

        private IConnection connection;

        public Service(FactoryCommand factory, IConnection connection)
        {
            this.factory = factory;
            this.connection = connection;
        }

        public void Start()
        {
            connection.Connect();
            while(true)
            {
                byte[] bytes = connection.Read();
                string commandString = Encoding.UTF8.GetString(bytes);
                ICommand command = factory.CreateCommand(commandString);
                command.Execute((x) => connection.Send(x));
            }
        }

      

        public void Stop()
        {
            connection.Close();
        }
    }
}
