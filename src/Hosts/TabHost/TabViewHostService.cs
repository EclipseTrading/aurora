using System.Threading.Tasks;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Host;
using Aurora.Core.ViewContainer;
using Aurora.TabHost.Views.Tab;
using Microsoft.Practices.Prism.Regions;

namespace Aurora.TabHost
{
    public class TabViewHostService : IViewHostService
    {
        private readonly IRegionManager regionManager;
        private readonly IPresenterFactory presenterFactory;

        public TabViewHostService(IRegionManager regionManager, IPresenterFactory presenterFactory)
        {
            this.presenterFactory = presenterFactory;
            this.regionManager = regionManager;
        }

        public async Task AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(TPresenter presenter, TActivityInfo activityInfo)
            where TPresenter : IPresenter<TViewModel, TView>
            where TViewModel : IViewModel
            where TView : FrameworkElement
            where TActivityInfo : ViewActivityInfo
        {
            var tabPresenter = await presenterFactory.CreatePresenterAsync<TabPresenter, TabViewModel, TabView>(
                new TabActivityInfo(activityInfo.Title, activityInfo.IsCloseable),
                new TypeOverride<IRegionManager>(regionManager));
            tabPresenter.View.Content = presenter.View;
            tabPresenter.RequestClose +=
                (s, e) =>
                {
                    var tp = tabPresenter;
                    var region = this.regionManager.Regions[TabHostRegion.Default];
                    region.Remove(tp.View);
                };
            
            
            var containedService = presenter as IViewContainerAware;
            if (containedService != null)
            {
                containedService.ViewContainerService = tabPresenter;
            }


            regionManager.RegisterViewWithRegion(TabHostRegion.Default, () => tabPresenter.View);
        }
    }
}