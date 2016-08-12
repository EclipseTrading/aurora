namespace Aurora.Core.Workspace
{
    public class WorkspaceLocation
    {
        public bool IsSelected { get; set; }
        public int TabOrder { get; set; }
        public int GroupIdx { get; set; }

        public bool IsFloating { get; set; }
        public double FloatingTop { get; set; }
        public double FloatingLeft { get; set; }
        public double FloatingWidth { get; set; }
        public double FloatingHeight { get; set; }

    }
}
