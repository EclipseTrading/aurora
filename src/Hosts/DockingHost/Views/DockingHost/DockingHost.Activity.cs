using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.DockingHost.Views.DockingHost
{
    [ActivityInfo(typeof(DockingHostActivityInfo))]
    public class DockingHostActivity : ViewHostActivity<DockingHostPresenter, DockingHostViewModel, DockingHostView, DockingHostActivityInfo>
    {
        private readonly IPresenterFactory presenterFactory;

        public DockingHostActivity(DockingHostActivityInfo activityInfo, IPresenterFactory presenterFactory) : base(activityInfo)
        {
            this.presenterFactory = presenterFactory;
        }

        protected override IViewHostService CreateViewHostService()
        {
            return new DockingViewHostService(HostRegionManager);
        }
    }
}
