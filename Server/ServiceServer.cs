﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyRPC.Commands;
using MyRPC.Interfaces;

namespace MyRPC.Server
{
    public delegate Task HandlerBytes(byte[] data);

    public class ServiceServer : IService
    {
        private FactoryCommand factory;

        private IConnection connection;

        public ServiceServer(FactoryCommand factory, IConnection connection)
        {
            this.factory = factory;
            this.connection = connection;
        }

        public async void Start()
        {
            await connection.Connect();
            while (true)
            {
                try
                {
                    byte[] bytes = await connection.Read();
                    string commandString = Encoding.UTF8.GetString(bytes);
                    try
                    {
                        ICommand command = factory.CreateCommand(commandString);
                        await command.Execute((x) => connection.Send(x));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        byte[] message_exception = Encoding.UTF8.GetBytes(ex.Message);
                        await connection.Send(message_exception);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);   
                    connection.Close();
                    await connection.Connect();
                }  
            }
        }


        public void Stop()
        {
            connection.Close();
        }
    }
}
