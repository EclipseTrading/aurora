using System.Threading.Tasks;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Host;
using Microsoft.Practices.Prism.Regions;

namespace Aurora.DockingHost.Views.DockingHost
{
    public class DockingViewHostService : IViewHostService
    {
        private readonly IRegionManager hostRegionManager;

        public DockingViewHostService(IRegionManager hostRegionManager)
        {
            this.hostRegionManager = hostRegionManager;
        }

        public Task AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(TPresenter presenter, TActivityInfo activityInfo) 
            where TPresenter : IPresenter<TViewModel, TView> 
            where TViewModel : IViewModel 
            where TView : FrameworkElement 
            where TActivityInfo : ViewActivityInfo
        {
            hostRegionManager.RegisterViewWithRegion(DockingHostRegion.Default, () => presenter);
            return Task.FromResult(0);
        }
    }
}