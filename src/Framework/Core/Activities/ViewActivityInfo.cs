using Aurora.Core.Container;
using Newtonsoft.Json;

namespace Aurora.Core.Activities
{
    public class ViewActivityInfo : ActivityInfo
    {
        [JsonConstructor]
        public ViewActivityInfo(string title, HostLocation location = HostLocation.Center, bool isCloseable = true)
        {
            Title = title;
            Location = location;
            IsCloseable = isCloseable;
        }

        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("location")]
        public HostLocation Location { get; private set; }
        [JsonProperty("isCloseable")]
        public bool IsCloseable { get; private set; }
    }
}