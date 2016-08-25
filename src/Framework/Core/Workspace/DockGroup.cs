using System.Collections.Generic;

namespace Aurora.Core.Workspace
{
    public class DockGroup
    {

        public DockGroup()
        {
            this.DockingViews = new List<DockingView>();
        }

        public List<DockingView> DockingViews { get; }
        public double Proportion { get; set; }
    }


}
