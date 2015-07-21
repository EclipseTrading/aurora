using System.Windows.Input;
using Aurora.Core;
using Aurora.Core.Host;

namespace Aurora.CommandBarHost.Views
{
    public class CommandBarHostPresenter : Presenter<CommandBarHostViewModel, CommandBarHostView, CommandBarHostActivityInfo>
    {
        public CommandBarHostPresenter(CommandBarHostActivityInfo activityInfo) : base(activityInfo)
        {
            
        }

        public void AddCommand(CommandInfo commandInfo, ICommand command)
        {
            this.ViewModel.Commands.Add(new CommandViewModel { Title = commandInfo.Title, Command = command});
        }
    }
}
