using System;
using System.Windows.Input;

namespace Aurora.Core.Host
{
    public interface ICommandBarService : IDisposable
    {
        void AddCommand(CommandInfo commandInfo, ICommand command);
    }
}