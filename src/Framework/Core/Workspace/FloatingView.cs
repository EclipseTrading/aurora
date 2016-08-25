using System;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{
    public class FloatingView
    {

        public FloatingView(Type presenterType, string viewName, JObject data, Rect location)
        {
            this.PresneterType = presenterType;
            this.ViewName = viewName;
            this.ViewData = data;
            this.Location = location;
        }

        public Type PresneterType { get; set; }
        public string ViewName { get; set; }
        public JObject ViewData { get; set; }
        public Rect Location { get; set; }
    }
}
