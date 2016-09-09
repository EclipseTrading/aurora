using System.Collections.Generic;

namespace Aurora.Core.Workspace
{
    public class DockingConfig
    {
        public DockingConfig()
        {
            this.GroupProportion = new List<double>();
        }
        public DockingOrientation Orientation { get; set; }
        public List<double> GroupProportion { get; set; }
    }
}
