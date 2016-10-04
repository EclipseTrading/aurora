using System;

namespace Aurora.Core.Container
{
    public interface ICommandBarService : IDisposable
    {
        void AddCommand(CommandBarItem menuItemCommand);
        void RemoveCommand(string commandId);
    }
}