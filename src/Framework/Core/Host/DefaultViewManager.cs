using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.Core.Host
{
    public class DefaultViewManager : IViewManager
    {
        private readonly Dictionary<HostLocation, IViewHostService> services = new Dictionary<HostLocation, IViewHostService>();
        private IViewHostService defaultViewHostService;

        public async Task AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(TPresenter view, TActivityInfo activityInfo) 
            where TPresenter : IPresenter<TViewModel, TView> 
            where TViewModel : IViewModel 
            where TView : FrameworkElement 
            where TActivityInfo : ViewActivityInfo
        {

            IViewHostService viewHostService;

            if (!services.ContainsKey(activityInfo.Location))
            {
                if (defaultViewHostService == null)
                {
                    throw new ArgumentException("No Host Defined at Given Location (" + activityInfo.Location + ")");
                }

                viewHostService = defaultViewHostService;
            }
            else
            {

                viewHostService = services[activityInfo.Location];
            }

            await viewHostService.AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(view, activityInfo);
        }

        public void RegisterViewHostService(HostLocation location, IViewHostService viewHostService)
        {
            services[location] = viewHostService;
        }

        public void SetDefaultViewHostService(IViewHostService viewHostService)
        {
            this.defaultViewHostService = viewHostService;
        }
    }
}