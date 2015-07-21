using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Host;

namespace Aurora.Core.Activities
{
    public abstract class ViewHostActivity<TPresenter, TViewModel, TView, TActivityInfo>
        : HostActivity<TPresenter, TViewModel, TView, TActivityInfo>
        where TView : FrameworkElement
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel, TView>
        where TActivityInfo : HostActivityInfo
    {
        protected ViewHostActivity(TActivityInfo activityInfo) : base(activityInfo)
        {
        }

        public override Task StartAsync()
        {
            var viewHostService = CreateViewHostService();
            ViewManager.RegisterViewHostService(ActivityInfo.Location, viewHostService);
            if (ActivityInfo.IsDefault)
            {
                ViewManager.SetDefaultViewHostService(viewHostService);
            }

            return base.StartAsync();
        }

        protected abstract IViewHostService CreateViewHostService();
    }
}