using System;
using System.Windows.Input;

namespace MyRPC.Commands
{
    public class CommandCreateFile : ICommand
    {
        public string[] Args { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] Flags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IHandler handler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute()
        {
            throw new NotImplementedException();
        }

       
    }

}
