using System.Collections.Generic;

namespace Aurora.Core.Container
{
    public class DefaultCommandBarServiceHost : ICommandBarServiceHost, ICommandBarService
    {
        private readonly Dictionary<string, ICommandBarService> commandBarServices = new Dictionary<string, ICommandBarService>();
        private ICommandBarService defaultCommandBarService;
        
        public void RegisterCommandBarService(string barName, ICommandBarService commandBarService)
        {
            this.commandBarServices[barName] = commandBarService;
        }

        public void RegisterDefaultCommandBarService(ICommandBarService commandBarService)
        {
            this.defaultCommandBarService = commandBarService;
        }

        public ICommandBarService GetCommandBarService(string barName)
        {
            return barName == null ? defaultCommandBarService : commandBarServices[barName];
        }

        public void AddCommand(CommandBarItem menuItemCommand)
        {
            defaultCommandBarService?.AddCommand(menuItemCommand);
        }

        public void RemoveCommand(string commandId)
        {
            defaultCommandBarService?.RemoveCommand(commandId);
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