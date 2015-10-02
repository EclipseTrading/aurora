using System.Windows.Input;
using Aurora.Core;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer.Views
{
    public class CommandBarContainerPresenter : Presenter<CommandBarContainerViewModel, CommandBarContainerActivityInfo>
    {
        public CommandBarContainerPresenter(CommandBarContainerActivityInfo activityInfo) : base(activityInfo)
        {
            
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.CommandOrientation = ActivityInfo.CommandOrientation;
        }

        public void AddCommand(CommandInfo commandInfo, ICommand command)
        {
            this.ViewModel.Commands.Add(new CommandViewModel { Title = commandInfo.Title, Command = command});
        }
    }
}
