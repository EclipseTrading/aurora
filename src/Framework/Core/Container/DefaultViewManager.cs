using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.Core.Container
{
    public class DefaultViewManager : IViewManager
    {
        private readonly Dictionary<HostLocation, IViewContainerService> services = new Dictionary<HostLocation, IViewContainerService>();
        private IViewContainerService defaultViewContainerService;

        public async Task AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(TPresenter view, TActivityInfo activityInfo) 
            where TPresenter : IPresenter<TViewModel, TView> 
            where TViewModel : IViewModel 
            where TView : FrameworkElement 
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

            await viewContainerService.AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(view, activityInfo);
        }

        public void RegisterViewContainerService(HostLocation location, IViewContainerService viewContainerService)
        {
            services[location] = viewContainerService;
        }

        public void SetDefaultViewContainerService(IViewContainerService viewContainerService)
        {
            this.defaultViewContainerService = viewContainerService;
        }
    }
}