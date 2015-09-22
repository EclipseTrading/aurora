using System.Threading.Tasks;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer.Views
{
    [ActivityInfo(typeof(CommandBarContainerActivityInfo))]
    public class CommandBarContainerActivity : ContainerActivity<CommandBarContainerPresenter, CommandBarContainerActivityInfo>
    {
        private readonly ICommandBarServiceHost commandBarServiceHost;
        
        public CommandBarContainerActivity(CommandBarContainerActivityInfo activityInfo, ICommandBarServiceHost commandBarServiceHost) 
            : base(activityInfo)
        {
            this.commandBarServiceHost = commandBarServiceHost;
        }

        public override async Task StartAsync()
        {
            var view = await ViewFactory.CreateActiveViewAsync<CommandBarContainerPresenter>(ActivityInfo);
            var commandBarService = new CommandBarService(view.Presenter);

            commandBarServiceHost.RegisterDefaultCommandBarService(commandBarService);

            ContainerService.SetViewContainer(ActivityInfo.Location, view.View);
        }
    }
}