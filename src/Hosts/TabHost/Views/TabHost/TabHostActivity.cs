using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.TabHost.Views.TabHost
{
    [ActivityInfo(typeof(TabHostActivityInfo))]
    public class TabHostActivity : ViewHostActivity<TabHostPresenter, TabHostViewModel, TabHostView, TabHostActivityInfo>
    {
        private readonly IPresenterFactory presenterFactory;

        public TabHostActivity(TabHostActivityInfo activityInfo, IPresenterFactory presenterFactory) : base(activityInfo)
        {
            this.presenterFactory = presenterFactory;
        }

        protected override IViewHostService CreateViewHostService()
        {
            return new TabViewHostService(HostRegionManager, presenterFactory);
        }
    }
}
