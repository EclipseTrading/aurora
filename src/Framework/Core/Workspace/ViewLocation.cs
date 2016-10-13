namespace Aurora.Core.Workspace
{
   
    public enum DockingState
    {
        Dock = 0,
        Float = 1,
        Hidden = 2,
        AutoHidden = 3,
        Document = 4
    }


    public enum DockingSide
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3,
        Tabbed = 4,
        None = 5
    }

    public class ViewLocation
    {
        public ViewLocation()
        {
            DockTarget = "";
            FloatTarget = "";
        }

        public string DockTarget { get; set; }
        public string FloatTarget { get; set; }
        public DockingSide DockSide { get; set; }
        public DockingState DockState { get; set; }
        public double DockWidth { get; set; }
        public double DockHeight { get; set; }
        public int DockIndex { get; set; }


        public bool IsFloating { get; set; }
        public double FloatingTop { get; set; }
        public double FloatingLeft { get; set; }
        public double FloatingWidth { get; set; }
        public double FloatingHeight { get; set; }
        public bool Minimized { get; set; }
        public bool Maximized { get; set; }

        public int TabOrderInDocument { get; set; }
        public int TabOrderInFloating { get; set; }
        public int TabOrderInDock { get; set; }

    }
}
