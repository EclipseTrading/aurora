using System.Threading.Tasks;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.ViewContainer;
using Aurora.TabContainer.Views.Tab;
using Microsoft.Practices.Prism.Regions;
using IViewContainerService = Aurora.Core.Container.IViewContainerService;
using System;

namespace Aurora.TabContainer
{
    public class TabViewContainerService : IViewContainerService
    {
        private readonly IRegionManager regionManager;
        private readonly IViewFactory viewFactory;

        public TabViewContainerService(IRegionManager regionManager, IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
            this.regionManager = regionManager;
        }

        public async Task<IDisposable> AddViewAsync<TActivityInfo>(ActiveView contentView, TActivityInfo activityInfo)
            where TActivityInfo : ViewActivityInfo
        {
            var activeView = await viewFactory.CreateActiveViewAsync<TabPresenter>(
                new TabActivityInfo(activityInfo.Title, activityInfo.IsCloseable),
                new TypeOverride<IRegionManager>(regionManager));

            var view = (TabView)activeView.View;
            view.Content = contentView.View;
            activeView.Presenter.RequestClose +=
                (s, e) =>
                {
                    var region = this.regionManager.Regions[TabContainerRegion.Default];
                    region.Remove(activeView.View);
                };
            
            
            var containedService = contentView.Presenter as IViewContainerAware;
            if (containedService != null)
            {
                containedService.ViewContainerService = activeView.Presenter;
            }


            regionManager.RegisterViewWithRegion(TabContainerRegion.Default, () => activeView.View);

            return new ActionDisposable(() => { });
        }
    }
}