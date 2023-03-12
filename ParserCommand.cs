using MyRPC.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public class ParserCommand : IParserCommand
    {
        public CommandData Parse(string str)
        {
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CommandData commandData = new CommandData();
            commandData.Name = words[0];
            List<string> args = new List<string>();
            List<string> flags = new List<string>();
            for(int i = 1; i < words.Length; i++)
            {
                if (words[i][0] == '-')
                {
                    for(int j = 1; j < words[i].Length; j++)
                    {
                        flags.Add(words[i][j].ToString());
                    }
                }
                else
                {
                    args.Add(words[i]);
                }
            }
            commandData.Flags = flags.ToArray();
            commandData.Args = args.ToArray();
            return commandData;
        }
    }
}
