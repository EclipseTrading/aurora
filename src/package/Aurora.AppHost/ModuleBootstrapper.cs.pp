using Aurora.Core.Container;
using Aurora.CommandBarContainer;
using Aurora.DockingContainer;
using Microsoft.Practices.Prism.Modularity;

namespace $rootnamespace$
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
            activityService.StartActivityAsync(new CommandBarContainerActivityInfo(HostLocation.Top));
            activityService.StartActivityAsync(new DockingContainerActivityInfo(HostLocation.Center, true));
        }
    }
}