using System.Windows;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Newtonsoft.Json;

namespace Aurora.Core.Activities
{
    public class ViewActivityInfo : ActivityInfo
    {
        [JsonConstructor]
        public ViewActivityInfo(string id, HostLocation location = HostLocation.Center, bool isCloseable = true)
        {
           // Title = title;
            Id = id;
            Location = location;
            IsCloseable = isCloseable;
        }

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("location")]
        public HostLocation Location { get; }
        [JsonProperty("isCloseable")]
        public bool IsCloseable { get; }

        public ViewLocation ViewLocation { get; set; }
        public string Id { get; }

        public object ViewData { get; set; }


        public DataTemplate HeaderTemplate { get; set; }
        public object HeaderContent { get; set; }
       

    }
}