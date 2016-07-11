using System;
using System.Windows.Input;

namespace Aurora.Core.Container
{
    public interface ICommandBarService : IDisposable
    {
        void AddCommand(CommandInfo commandInfo, ICommand command);
        void RemoveCommand(CommandInfo commandInfo);
    }
}