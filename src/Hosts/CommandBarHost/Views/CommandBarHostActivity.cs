using System.Threading.Tasks;
using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.CommandBarHost.Views
{
    [ActivityInfo(typeof(CommandBarHostActivityInfo))]
    public class CommandBarHostActivity : HostActivity<CommandBarHostPresenter, CommandBarHostViewModel, CommandBarHostView, CommandBarHostActivityInfo>
    {
        private readonly ICommandBarServiceHost commandBarServiceHost;
        
        public CommandBarHostActivity(CommandBarHostActivityInfo activityInfo, ICommandBarServiceHost commandBarServiceHost) 
            : base(activityInfo)
        {
            this.commandBarServiceHost = commandBarServiceHost;
        }

        public override async Task StartAsync()
        {
            var presenter = await PresenterFactory
                .CreatePresenterAsync<CommandBarHostPresenter, CommandBarHostViewModel, CommandBarHostView>(ActivityInfo);
            var commandBarService = new CommandBarService(presenter);

            commandBarServiceHost.RegisterDefaultCommandBarService(commandBarService);

            HostService.SetViewHost(ActivityInfo.Location, presenter.View);
        }
    }
}