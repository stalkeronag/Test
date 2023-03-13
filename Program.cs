// See https://aka.ms/new-console-template for more information
using MyRPC;

Console.WriteLine("Hello, World!");
IParserCommand parser = new ParserCommand();
FactoryCommand factory = new CommandCreator(parser);
Service service = new Service(factory, new Pipe());
service.Start();
service.Stop();
