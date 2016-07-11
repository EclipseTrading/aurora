using System.Windows.Input;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer.Views
{
    public class CommandBarService : ICommandBarService
    {
        private readonly CommandBarContainerPresenter presenter;

        public CommandBarService(CommandBarContainerPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void AddCommand(CommandInfo commandInfo, ICommand command)
        {
            presenter.AddCommand(commandInfo, command);
        }

        public void RemoveCommand(CommandInfo commandInfo)
        {
            presenter.RemoveCommand(commandInfo);
        }

        public void Dispose()
        {
            this.presenter.Dispose();
        }
    }
}