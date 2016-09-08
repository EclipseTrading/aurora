using System.Collections.Generic;
using System.Windows;

namespace Aurora.Core.Workspace
{
    public class WorkspaceLayout
    {

        public WorkspaceLayout()
        {
            this.FloatingViews = new List<FloatingViewConfig>();
            this.DockGroups = new List<DockGroupConfig>();
            this.MainWindowRect = new Rect(0,0, 800,600);
        }

        public List<FloatingViewConfig> FloatingViews { get; }
        public List<DockGroupConfig> DockGroups { get; }
        public DockingOrientation Orientation { get; set; }
        public Rect MainWindowRect { get; set; }
        public bool Minimized { get; set; }
        public bool Maximized { get; set; }
        public string Name { get; set; }
    }
}
