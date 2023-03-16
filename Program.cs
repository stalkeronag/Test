// See https://aka.ms/new-console-template for more information
using MyRPC;
using MyRPC.Server;
using System.Net;

IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
IConnection connection = new TcpServerConnections(endPoint);

Console.WriteLine("Hello, World!");
IParserCommand parser = new ParserCommand();
FactoryCommand factory = new CommandCreator(parser);
Service service = new Service(factory, connection);
service.Start();
service.Stop();
