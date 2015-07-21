using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Aurora.Core.Host
{
    public class DefaultCommandBarServiceHost : ICommandBarServiceHost
    {
        private readonly Dictionary<string, ICommandBarService> commandBarServices = new Dictionary<string, ICommandBarService>();
        private ICommandBarService defaultCommandBarService;
        private readonly List<CommandObject> cache = new List<CommandObject>();

        public void AddCommand(CommandInfo commandInfo, ICommand command)
        {
            if (!string.IsNullOrEmpty(commandInfo.BarName) && commandBarServices.ContainsKey(commandInfo.BarName))
            {
                commandBarServices[commandInfo.BarName].AddCommand(commandInfo, command);
            }
            else if (string.IsNullOrEmpty(commandInfo.BarName) && defaultCommandBarService != null)
            {
                defaultCommandBarService.AddCommand(commandInfo, command);

            }
            else
            {
                cache.Add(new CommandObject { CommandInfo = commandInfo, Command = command });
            }
        }

        public void RegisterCommandBarService(string barName, ICommandBarService commandBarService)
        {
            this.commandBarServices[barName] = commandBarService;
            UpdateFromCache(commandBarService, s => s == barName);
        }
        public void RegisterDefaultCommandBarService(ICommandBarService commandBarService)
        {
            this.defaultCommandBarService = commandBarService;
            UpdateFromCache(commandBarService, string.IsNullOrEmpty);
        }

        private void UpdateFromCache(ICommandBarService commandBarService, Func<string, bool> f)
        {
            var toAdd = this.cache.Where(c => f(c.CommandInfo.BarName)).ToList();

            toAdd.ForEach(i =>
            {
                commandBarService.AddCommand(i.CommandInfo, i.Command);
                this.cache.Remove(i);
            });
        }

        internal class CommandObject
        {
            public CommandInfo CommandInfo { get; set; }
            public ICommand Command { get; set; }
        }

        public void Dispose()
        {
            foreach (var commandBarService in commandBarServices)
            {
                commandBarService.Value.Dispose();
            }
        }
    }
}