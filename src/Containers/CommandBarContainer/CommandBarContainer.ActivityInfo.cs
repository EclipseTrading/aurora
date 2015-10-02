using System.Windows.Controls;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer
{
    public class CommandBarContainerActivityInfo : ContainerActivityInfo
    {
        public CommandBarContainerActivityInfo(HostLocation location) : base(location)
        {
        }

        public Orientation CommandOrientation { get; set; } = Orientation.Horizontal;
    }
}
