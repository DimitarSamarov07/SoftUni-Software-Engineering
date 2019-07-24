using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string inputLine)
        {
            string[] commandTokes = inputLine
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandTokes[0] + COMMAND_POSTFIX;
            string[] commandArgs = commandTokes
                .Skip(1)
                .ToArray();

            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (type == null)
            {
                throw new NullReferenceException("type is missing!");
            }

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            string result = instance.Execute(commandArgs);

            return result;
        }
    }
}
