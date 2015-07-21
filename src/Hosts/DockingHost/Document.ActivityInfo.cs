using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.DockingHost
{
    public class DocumentActivityInfo : ViewActivityInfo
    {
        public DocumentActivityInfo(string title, HostLocation location = HostLocation.Center, bool isCloseable = false) : base(title, location, isCloseable)
        {
        }
    }
}
