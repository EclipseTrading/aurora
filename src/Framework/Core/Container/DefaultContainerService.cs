using System.Windows;
using Microsoft.Practices.Prism.Regions;

namespace Aurora.Core.Container
{
    public class DefaultContainerService : IContainerService
    {
        private readonly IRegionManager regionManager;

        public DefaultContainerService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void SetViewContainer<TView>(HostLocation location, TView view) where TView : DependencyObject
        {
            regionManager.AddToRegion(GetRegionName(location), view);
        }
        
        private static string GetRegionName(HostLocation location)
        {
            return location + "Host";
        }
    }
}