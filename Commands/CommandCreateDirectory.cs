namespace MyRPC.Commands
{
    public class CommandCreateDirectory : ICommand
    {
        public string[] Args { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] Flags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void ExecuteWithCallback(Action<byte[]> callback)
        {
            throw new NotImplementedException();
        }
    }

}
