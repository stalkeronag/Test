using MyRPC.Client;
using MyRPC.Commands;
using MyRPC.Interfaces;
using MyRPC.Server;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;



string jsonString = "";
using(StreamReader reader = new StreamReader("..\\..\\..\\Server\\ConfigServer.json"))
{
   jsonString =  reader.ReadToEnd();
}


ServerConfig config = JsonSerializer.Deserialize<ServerConfig>(jsonString);
ServerConfig.currentDirectory = "C:\\";
IService service;
Console.WriteLine("select mode 1:server, other:client");
IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(config.IpAddress), config.Port);
int mode = int.Parse(Console.ReadLine());
if(mode == 1)
{
    IConnection connection = new TcpServerConnections(endPoint);
    IParserCommand parser = new ParserCommand();
    FactoryCommand factory = new CommandCreator(parser);
    ICommand helloCommand = new HelloCommand() { Name = "Hello" };
    ICommand changeDirectory = new CommandChangeDirectory() { Name = "Cd" };
    ICommand listDir = new CommandShowFilesAndDirectories() { Name = "List" };
    ICommand testChat = new TestChatCommand(connection) { Name = "Chat"};
    ICommand senderGmail = new CommandSendGmail(connection) { Name = "Gmail" };
    factory.AddCommand(helloCommand);
    factory.AddCommand(changeDirectory);
    factory.AddCommand(listDir);
    factory.AddCommand(testChat);
    factory.AddCommand(senderGmail);
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
