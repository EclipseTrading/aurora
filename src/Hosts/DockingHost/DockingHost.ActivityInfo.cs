using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.DockingHost
{
    public class DockingHostActivityInfo : HostActivityInfo
    {
        public DockingHostActivityInfo(HostLocation location = HostLocation.Center, bool isCloseable = false) : base(location, isCloseable)
        {
        }
    }
}
