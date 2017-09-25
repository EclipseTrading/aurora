using System.Collections.Generic;
using System.Windows;

namespace Aurora.Core.Workspace
{
    public class WorkspaceLayout
    {
        public WorkspaceLayout()
        {
            this.Views = new List<WorkspaceViewConfig>();
            this.MainWindowRect = new Rect(0, 0, 800, 600);
        }

        public WorkspaceLayout(Rect mainWindowRect, bool minimized, bool maximized, IReadOnlyList<WorkspaceViewConfig> views)
        {
            MainWindowRect = mainWindowRect;
            Minimized = minimized;
            Maximized = maximized;
            this.Views = views;
        }

        public IReadOnlyList<WorkspaceViewConfig> Views { get; }
        public Rect MainWindowRect { get; }
        public bool Minimized { get; }
        public bool Maximized { get; }
    }
}
