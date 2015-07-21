using Aurora.Core;

namespace Aurora.DockingHost.Views.DockingHost
{
    public class DockingHostPresenter : Presenter<DockingHostViewModel, DockingHostView, DockingHostActivityInfo>
    {
        public DockingHostPresenter(DockingHostActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }
}
