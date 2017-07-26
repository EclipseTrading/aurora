using System;
using System.Windows;

namespace Aurora.Core.Workspace
{
    public class WorkspaceViewConfig
    {
        public WorkspaceViewConfig(Type presenterType, string viewId, object data)
        {
            this.PresenterType = presenterType;
            this.ViewId = viewId;
            this.ViewData = data;
            this.DockTarget = "";
            this.FloatingDockTarget = "";
        }

        public Type PresenterType { get; set; }
        public string ViewId { get; set; }
        public string ViewTitle { get; set; }
        public object ViewData { get; set; }
        public string DockTarget { get; set; }
        public DockingSide DockSide { get; set; }
        public DockingState DockState { get; set; }
        public double DockWidth { get; set; }
        public double DockHeight { get; set; }
        public int DockIndex { get; set; }
        public Rect FloatingLocation { get; set; }
        public bool Maximized { get; set; }
        public bool Minimized { get; set; }
        public string FloatingDockTarget { get; set; }
        public int FloatingDockIndex { get; set; }
        public DockingSide FloatingDockSide { get; set; }
        public double FloatingDockWidth { get; set; }
        public double FloatingDockHeight { get; set; }
        public int TabOrderInDocument { get; set; }
        public int TabOrderInFloating { get; set; }
        public int TabOrderInDock { get; set; }
    }
}
