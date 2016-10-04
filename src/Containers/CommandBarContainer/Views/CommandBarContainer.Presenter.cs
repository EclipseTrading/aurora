using System.Linq;
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

        public void AddCommand(CommandBarItem menuItemCommand)
        {
            this.ViewModel.Commands.Add(menuItemCommand);
        }

        public void RemoveCommand(string commandId)
        {
            foreach (var toRemove in this.ViewModel.Commands.Where(e => e.Id.Equals(commandId)).ToList())
            {
                this.ViewModel.Commands.Remove(toRemove);
            }
        }
    }
}
