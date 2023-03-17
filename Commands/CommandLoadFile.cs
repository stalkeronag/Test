using MyRPC.Interfaces;
using MyRPC.Server;

namespace MyRPC.Commands
{
    public class CommandLoadFile : ICommand
    {
        public string[] Args { get; set; }
        public string[] Flags { get; set; }

        public void Execute(HandlerBytes handler)
        {
            throw new NotImplementedException();
        }
    }

}
