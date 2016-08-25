using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core.Container
{
    public class DefaultViewManager : IViewManager
    {
        private readonly Dictionary<HostLocation, IViewContainerService> services = new Dictionary<HostLocation, IViewContainerService>();
        private IViewContainerService defaultViewContainerService;

        public async Task<IDisposable> AddViewAsync<TActivityInfo>(ActiveView view, TActivityInfo activityInfo)
            where TActivityInfo : ViewActivityInfo
        {
            IViewContainerService viewContainerService;

            if (!services.ContainsKey(activityInfo.Location))
            {
                if (defaultViewContainerService == null)
                {
                    throw new ArgumentException("No Host Defined at Given Location (" + activityInfo.Location + ")");
                }

                viewContainerService = defaultViewContainerService;
            }
            else
            {
                viewContainerService = services[activityInfo.Location];
            }

            return await viewContainerService.AddViewAsync(view, activityInfo);            

        }

        public void RegisterViewContainerService(HostLocation location, IViewContainerService viewContainerService)
        {
            services[location] = viewContainerService;
        }

        public void SetDefaultViewContainerService(IViewContainerService viewContainerService)
        {
            this.defaultViewContainerService = viewContainerService;
        }

        public IViewContainerService GetViewContainerService(HostLocation location)
        {
            if (!services.ContainsKey(location))
                return this.defaultViewContainerService;

            return services[location];
        }

    }
}