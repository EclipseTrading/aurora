using System.Threading.Tasks;
using Aurora.Core;
using Aurora.Core.Activities;
using Microsoft.Practices.Prism.Regions;
using IViewContainerService = Aurora.Core.Container.IViewContainerService;
using System;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class DockingViewContainerService : IViewContainerService
    {
        private readonly IRegionManager regionManager;

        public DockingViewContainerService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async Task<IDisposable> AddViewAsync<TActivityInfo>(ActiveView contentView, TActivityInfo activityInfo)
            where TActivityInfo : ViewActivityInfo
        {
            var a = new Container { View = contentView };

            regionManager.RegisterViewWithRegion(DockingContainerRegion.Default, () => a.View);
            return await Task.FromResult(new ActionDisposable(() => {
                regionManager.Regions[DockingContainerRegion.Default].Remove(contentView);
                contentView = null;
                a.View = null;
            }));            
        }

        private class Container
        {
            public ActiveView View { get; set; }
        }
    }
}