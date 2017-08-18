using System.Windows.Controls;
using Aurora.CommandBarContainer;
using Aurora.Core.Container;
using Aurora.SyncfusionDockingContainer;
using Prism.Modularity;

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
            activityService.StartActivityAsync(new CommandBarContainerActivityInfo(HostLocation.AppMenu) { CommandOrientation = Orientation.Vertical, ShowContainerFrame = false});
            activityService.StartActivityAsync(new DockingContainerActivityInfo(HostLocation.Center, true));
        }
    }
}