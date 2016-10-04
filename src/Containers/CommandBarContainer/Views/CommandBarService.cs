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

        public void AddCommand(CommandBarItem menuItemCommand)
        {
            presenter.AddCommand(menuItemCommand);
        }

        public void RemoveCommand(string commandId)
        {
            presenter.RemoveCommand(commandId);
        }

        public void Dispose()
        {
            this.presenter.Dispose();
        }
    }
}