using System.Threading.Tasks;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer.Views
{
    [ActivityInfo(typeof(CommandBarContainerActivityInfo))]
    public class CommandBarContainerActivity : ContainerActivity<CommandBarContainerPresenter, CommandBarContainerViewModel, CommandBarContainerView, CommandBarContainerActivityInfo>
    {
        private readonly ICommandBarServiceHost commandBarServiceHost;
        
        public CommandBarContainerActivity(CommandBarContainerActivityInfo activityInfo, ICommandBarServiceHost commandBarServiceHost) 
            : base(activityInfo)
        {
            this.commandBarServiceHost = commandBarServiceHost;
        }

        public override async Task StartAsync()
        {
            var presenter = await PresenterFactory
                .CreatePresenterAsync<CommandBarContainerPresenter, CommandBarContainerViewModel, CommandBarContainerView>(ActivityInfo);
            var commandBarService = new CommandBarService(presenter);

            commandBarServiceHost.RegisterDefaultCommandBarService(commandBarService);

            ContainerService.SetViewContainer(ActivityInfo.Location, presenter.View);
        }
    }
}