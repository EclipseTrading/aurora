using System.Collections.Generic;
using System.Windows;

namespace Aurora.Core.Workspace
{
    public class WorkspaceLayout
    {
        public WorkspaceLayout()
        {
            this.WorkspaceViews = new List<WorkspaceViewConfig>();
            this.MainWindowRect = new Rect(0, 0, 800, 600);
        }

        public List<WorkspaceViewConfig> WorkspaceViews { get; }
        public Rect MainWindowRect { get; set; }
        public bool Minimized { get; set; }
        public bool Maximized { get; set; }
        public string Name { get; set; }
    }
}
