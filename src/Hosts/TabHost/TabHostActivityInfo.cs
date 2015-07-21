using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.TabHost
{
    public class TabHostActivityInfo : HostActivityInfo
    {
        public TabHostActivityInfo(HostLocation location, bool isDefault = false) : base(location, isDefault)
        {
        }
    }
}