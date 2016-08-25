using System.Collections.Generic;
using System.Windows;

namespace Aurora.Core.Workspace
{
    public class WorkspaceLayout
    {

        public WorkspaceLayout()
        {
            this.FloatingViews = new List<FloatingView>();
            this.DockGroups = new List<DockGroup>();
            this.MainWindowRect = new Rect(0,0, 800,600);
        }

        public List<FloatingView> FloatingViews { get; }
        public List<DockGroup> DockGroups { get; }
        public DockingOrientation Orientation { get; set; }
        public Rect MainWindowRect { get; set; }
        public string Name { get; set; }
    }
}
