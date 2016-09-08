using System;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{
    public class DockingViewConfig
    {
        public DockingViewConfig(Type presenterType, string viewName, JObject data, int order, bool selected)
        {
            this.PresenterType = presenterType;
            this.ViewName = viewName;
            this.ViewData = data;
            this.Order = order;
            this.Selected = selected;
        }

        public Type PresenterType { get; set; }
        public string ViewName { get; set; }
        public JObject ViewData { get; set; }
        public int Order { get; set; }
        public bool Selected { get; set; }
    }
}
