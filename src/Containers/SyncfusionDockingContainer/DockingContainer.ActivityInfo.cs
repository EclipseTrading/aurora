using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.SyncfusionDockingContainer
{
    public class DockingContainerActivityInfo : ContainerActivityInfo
    {
        public DockingContainerActivityInfo(HostLocation location = HostLocation.Center, bool isCloseable = false) : base(location, isCloseable)
        {
        }
    }
}
