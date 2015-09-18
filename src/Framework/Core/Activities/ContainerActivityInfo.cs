using Aurora.Core.Container;

namespace Aurora.Core.Activities
{
    public class ContainerActivityInfo : ActivityInfo
    {
        public ContainerActivityInfo(HostLocation location = HostLocation.Center, bool isDefault = false)
        {
            Location = location;
            IsDefault = isDefault;
        }

        public HostLocation Location { get; private set; }

        public bool IsDefault { get; private set; }
    }
}