using MyRPC.Interfaces;
using MyRPC.Server;

namespace MyRPC.Commands
{
    public class CommandLoadFile : ICommand
    {
        public string[] Args { get; set; }
        public string[] Flags { get; set; }
        public bool IsCompleted { get; set; }

        public string Name { get; set; }


        public async Task Execute(HandlerBytes handler)
        {
            throw new NotImplementedException();
        }
    }

}
