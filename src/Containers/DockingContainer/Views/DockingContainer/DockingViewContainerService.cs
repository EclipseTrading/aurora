using System.Threading.Tasks;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.ViewContainer;
using Aurora.DockingContainer.Views.Document;
using Microsoft.Practices.Prism.Regions;
using IViewContainerService = Aurora.Core.Container.IViewContainerService;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class DockingViewContainerService : IViewContainerService
    {
        private readonly IRegionManager regionManager;

        public DockingViewContainerService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async Task AddViewAsync<TActivityInfo>(ActiveView contentView, TActivityInfo activityInfo) 
            where TActivityInfo : ViewActivityInfo
        {
            regionManager.RegisterViewWithRegion(DockingContainerRegion.Default, () => contentView);
            await Task.FromResult(0);
        }
    }
}