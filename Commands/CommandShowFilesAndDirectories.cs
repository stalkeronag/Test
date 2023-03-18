using MyRPC.Interfaces;
using MyRPC.Server;
using System.Text;

namespace MyRPC.Commands
{
    public class CommandShowFilesAndDirectories : ICommand
    {
        public string[] Args { get; set; }
        public string[] Flags { get; set; }

        public string Name { get; set; }


        public void Execute(HandlerBytes handler)
        {
            DirectoryInfo info = new DirectoryInfo(ServerConfig.currentDirectory);
            StringBuilder builder= new StringBuilder();
            var fileNames = info.GetFiles();
            foreach ( var file in fileNames )
            {
                builder.Append(file.Name + " " + file.CreationTime + "\n");
            }
            var dirNames = info.GetDirectories();
            foreach ( var dir in dirNames )
            {
                builder.Append(dir.FullName +" " + dir.CreationTime+ "\n");
            }
            string result = builder.ToString();
            byte[] resultInBytes = Encoding.UTF8.GetBytes(result);
            handler.Invoke(resultInBytes);
            Console.WriteLine(result);
        }
    }

}
