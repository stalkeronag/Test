using System;
using System.Net.Http.Headers;
using MyRPC.Commands;
using MyRPC.Interfaces;

namespace MyRPC.Server
{

    public class CommandCreator : FactoryCommand
    {
        private Dictionary<string, ICommand> dictCommand;

        private IParserCommand parser;


        public CommandCreator(IParserCommand parser)
        {
            this.parser = parser;
            dictCommand = new Dictionary<string, ICommand>();
        }


        public override ICommand CreateCommand(string command_string)
        {
            CommandData commandData = parser.Parse(command_string);
            string[] flags = commandData.Flags;
            string[] args = commandData.Args;
            string nameCommand = commandData.Name;
            if (dictCommand.ContainsKey(nameCommand))
            {
                ICommand command = dictCommand[nameCommand];
                AddFlagsAndArgs(command, args, flags);
                return command;
            }
            throw new CommandException("command not found");
        }

        private void AddFlagsAndArgs(ICommand command, string[] args, string[] flags)
        {
            command.Flags = flags;
            command.Args = args;
        }

        public override void AddCommand(ICommand command)
        {
            dictCommand.Add(command.Name, command);
        }
    }

}
