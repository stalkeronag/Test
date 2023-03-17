using MyRPC.Client;
using MyRPC.Interfaces;
using MyRPC.Server;
using System.Net;
using System.Net.Http.Headers;

IService service;
Console.WriteLine($"select mode 1:server, other:client");
IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
int mode = int.Parse(Console.ReadLine());
if(mode == 1)
{
    IConnection connection = new TcpServerConnections(endPoint);
    IParserCommand parser = new ParserCommand();
    FactoryCommand factory = new CommandCreator(parser);
    service = new ServiceServer(factory, connection);
    service.Start();
}
else
{
    IConnection connection = new TcpClientConnection(endPoint);
    service = new ServiceClient(connection);
    service.Start();
}
service.Stop();
