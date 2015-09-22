using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.DockingContainer
{
    public class DocumentActivityInfo : ViewActivityInfo
    {
        public DocumentActivityInfo(string title, HostLocation location = HostLocation.Center, bool isCloseable = false) : base(title, location, isCloseable)
        {
        }
    }
}
