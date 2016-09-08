using System.Collections.Generic;

namespace Aurora.Core.Workspace
{
    public class DockGroupConfig
    {

        public DockGroupConfig()
        {
            this.DockingViews = new List<DockingViewConfig>();
        }

        public List<DockingViewConfig> DockingViews { get; }
        public double Proportion { get; set; }
    }


}
