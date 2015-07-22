using System.Threading.Tasks;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;
using Microsoft.Practices.Prism.Regions;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class DockingViewContainerService : IViewContainerService
    {
        private readonly IRegionManager hostRegionManager;

        public DockingViewContainerService(IRegionManager hostRegionManager)
        {
            this.hostRegionManager = hostRegionManager;
        }

        public Task AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(TPresenter presenter, TActivityInfo activityInfo) 
            where TPresenter : IPresenter<TViewModel, TView> 
            where TViewModel : IViewModel 
            where TView : FrameworkElement 
            where TActivityInfo : ViewActivityInfo
        {
            hostRegionManager.RegisterViewWithRegion(DockingContainerRegion.Default, () => presenter);
            return Task.FromResult(0);
        }
    }
}