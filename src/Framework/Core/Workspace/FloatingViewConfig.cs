using System;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{
    public class FloatingViewConfig
    {

        public FloatingViewConfig(Type presenterType, string viewName, JObject data, 
            Rect location, bool maximized = false, bool minimized = false)
        {
            this.PresneterType = presenterType;
            this.ViewName = viewName;
            this.ViewData = data;
            this.Location = location;
            this.Maximized = maximized;
            this.Minimized = minimized;
        }

        public Type PresneterType { get; set; }
        public string ViewName { get; set; }
        public JObject ViewData { get; set; }
        public Rect Location { get; set; }
        public bool Maximized { get; set; }
        public bool Minimized { get; set; }
    }
}
