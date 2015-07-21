using Aurora.Core.Host;

namespace Aurora.Core.Activities
{
    public class HostActivityInfo : ActivityInfo
    {
        public HostActivityInfo(HostLocation location = HostLocation.Center, bool isDefault = false)
        {
            Location = location;
            IsDefault = isDefault;
        }
        
        public HostLocation Location { get; }

        public bool IsDefault { get; }
    }
}