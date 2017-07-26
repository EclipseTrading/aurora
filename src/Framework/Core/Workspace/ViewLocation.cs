namespace Aurora.Core.Workspace
{
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
