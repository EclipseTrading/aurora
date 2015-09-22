using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.TabContainer
{
    public class TabContainerActivityInfo : ContainerActivityInfo
    {
        public TabContainerActivityInfo(HostLocation location, bool isDefault = false) : base(location, isDefault)
        {
        }
    }
}