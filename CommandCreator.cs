using System;
using System.Net.Http.Headers;
using MyRPC.Commands;

namespace MyRPC
{
    public enum Command
    {
        Mkdir = 12,
        List = 11,
        RemoveDir,
        RemoveFile,
        Load,
        Install
    }


    public class CommandCreator : FactoryCommand
    {
        private Dictionary<Command, ICommand> dictCommand;

        private IParserCommand parser;

        public CommandCreator(IParserCommand parser)
        {
            this.parser = parser;
            dictCommand = new Dictionary<Command, ICommand>
            {
                { Command.Mkdir, new CommandCreateDirectory() },
                { Command.RemoveDir, new CommandDeleteDirectory() },
                { Command.List, new CommandShowFilesAndDirectories() },
                { Command.RemoveFile, new CommandDeleteFile() },
            };
        }

        public override ICommand CreateCommand(string command_string)
        {
            CommandData commandData = parser.Parse(command_string);
            string[] flags = commandData.Flags;
            string[] args = commandData.Args;
            string nameCommand = commandData.Name;
            foreach(var item in dictCommand.Keys)
            {
                if(item.ToString() == nameCommand)
                {
                    ICommand command = dictCommand[item];
                    AddFlagsAndArgs(command, args, flags);
                    return command;
                }
            }
            throw new CommandException("command not found");
        }

        private void AddFlagsAndArgs(ICommand command, string[] args, string[] flags)
        {
            command.Flags = flags;
            command.Args = args;
        }
    }

}
