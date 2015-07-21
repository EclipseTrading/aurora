using Aurora.CommandBarHost;
using Aurora.Core.Host;
using Aurora.DockingHost;
using Microsoft.Practices.Prism.Modularity;

namespace Aurora.Sample.Host
{
    public class ModuleBootstrapper : IModule
    {
        private readonly IActivityService activityService;

        public ModuleBootstrapper(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        public void Initialize()
        {
            activityService.StartActivityAsync(new CommandBarHostActivityInfo(HostLocation.Top));
            activityService.StartActivityAsync(new DockingHostActivityInfo(HostLocation.Center, true));
        }
    }
}