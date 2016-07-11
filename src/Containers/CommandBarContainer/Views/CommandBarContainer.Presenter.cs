using System.Linq;
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
            this.ViewModel.ShowContainerFrame = ActivityInfo.ShowContainerFrame;
        }

        public void AddCommand(CommandInfo commandInfo, ICommand command)
        {
            this.ViewModel.Commands.Add(new CommandViewModel
            {
                Title = commandInfo.Title,
                Command = command,
                Description = commandInfo.Description,
                IconPath = commandInfo.IconPath
            });
        }

        public void RemoveCommand(CommandInfo commandInfo)
        {
            foreach (var toRemove in this.ViewModel.Commands.Where(e => e.Title.Equals(commandInfo.Title)).ToList())
            {
                this.ViewModel.Commands.Remove(toRemove);
            }
        }
    }
}
