using System.Windows.Input;
using Aurora.Core.Host;

namespace Aurora.CommandBarHost.Views
{
    public class CommandBarService : ICommandBarService
    {
        private readonly CommandBarHostPresenter presenter;

        public CommandBarService(CommandBarHostPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void AddCommand(CommandInfo commandInfo, ICommand command)
        {
            presenter.AddCommand(commandInfo, command);
        }

        public void Dispose()
        {
            this.presenter.Dispose();
        }
    }
}