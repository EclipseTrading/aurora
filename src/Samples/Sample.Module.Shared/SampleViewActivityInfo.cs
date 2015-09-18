using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.Sample.Module.Shared
{
    public class SampleViewActivityInfo : ViewActivityInfo
    {
        public string MessageFormat { get; set; }

        public SampleViewActivityInfo(string title, HostLocation location = HostLocation.Center, bool isCloseable = false) 
            : base(title, location, isCloseable)
        {
            this.MessageFormat = "Hi, {0}";
        }
    }
}
