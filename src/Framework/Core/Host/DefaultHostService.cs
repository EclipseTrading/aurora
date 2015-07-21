using System.Windows;
using Microsoft.Practices.Prism.Regions;

namespace Aurora.Core.Host
{
    public class DefaultHostService : IHostService
    {
        private readonly IRegionManager regionManager;

        public DefaultHostService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void SetViewHost<TView>(HostLocation location, TView view) where TView : FrameworkElement
        {
            regionManager.AddToRegion(GetRegionName(location), view);
        }
        
        private static string GetRegionName(HostLocation location)
        {
            return location + "Host";
        }
    }
}