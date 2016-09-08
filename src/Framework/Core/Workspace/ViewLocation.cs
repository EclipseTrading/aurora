namespace Aurora.Core.Workspace
{
    public class ViewLocation
    {
        public bool IsSelected { get; set; }
        public int Order { get; set; }
        public int GroupIdx { get; set; }
        public double DockProportion { get; set; }
        public DockingOrientation Orientation { get; set; }
      
        public bool IsFloating { get; set; }
        public double FloatingTop { get; set; }
        public double FloatingLeft { get; set; }
        public double FloatingWidth { get; set; }
        public double FloatingHeight { get; set; }
        public bool Minimized { get; set; }
        public bool Maximized { get; set; }

    }
}
