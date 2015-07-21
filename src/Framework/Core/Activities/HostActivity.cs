using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Host;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public class HostActivity<TPresenter, TViewModel, TView, TActivityInfo>
        : IActivity<TActivityInfo>
        where TView : FrameworkElement
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel, TView>
        where TActivityInfo : HostActivityInfo
    {
        private IRegionManager hostRegionManager;
        public TActivityInfo ActivityInfo { get; set; }

        protected HostActivity(TActivityInfo activityInfo)
        {
            ActivityInfo = activityInfo;
        }

        [Dependency]
        public IHostService HostService { get; set; }

        [Dependency]
        public IViewManager ViewManager { get; set; }

        [Dependency]
        public IPresenterFactory PresenterFactory { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public IRegionManager HostRegionManager => 
            hostRegionManager ?? (hostRegionManager = RegionManager.CreateRegionManager());

        public virtual async Task StartAsync()
        {
            var presenter = await PresenterFactory.CreatePresenterAsync<TPresenter, TViewModel, TView>(ActivityInfo,
                new TypeOverride<IRegionManager>(HostRegionManager));
            HostService.SetViewHost(ActivityInfo.Location, presenter.View);
        }
    }
}