using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.Sample.Module.Shared
{
    public class SampleViewActivityInfo : ViewActivityInfo
    {
        public string MessageFormat { get; set; } = "Hi, {0}";

        public SampleViewActivityInfo(string title, HostLocation location = HostLocation.Center, bool isCloseable = false) 
            : base(title, location, isCloseable)
        {
        }
    }
}
