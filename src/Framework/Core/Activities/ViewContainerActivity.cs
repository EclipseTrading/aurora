using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Container;

namespace Aurora.Core.Activities
{
    public abstract class ViewContainerActivity<TPresenter, TViewModel, TView, TActivityInfo>
        : ContainerActivity<TPresenter, TViewModel, TView, TActivityInfo>
        where TView : FrameworkElement
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel, TView>
        where TActivityInfo : ContainerActivityInfo
    {
        protected ViewContainerActivity(TActivityInfo activityInfo) : base(activityInfo)
        {
        }

        public override Task StartAsync()
        {
            var viewContainerService = CreateViewContainerService();
            ViewManager.RegisterViewContainerService(ActivityInfo.Location, viewContainerService);
            if (ActivityInfo.IsDefault)
            {
                ViewManager.SetDefaultViewContainerService(viewContainerService);
            }

            return base.StartAsync();
        }

        protected abstract IViewContainerService CreateViewContainerService();
    }
}