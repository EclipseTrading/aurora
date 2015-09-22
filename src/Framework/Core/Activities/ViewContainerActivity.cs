using System.Threading.Tasks;
using Aurora.Core.Container;

namespace Aurora.Core.Activities
{
    public abstract class ViewContainerActivity<TPresenter, TActivityInfo>
        : ContainerActivity<TPresenter, TActivityInfo>
        where TPresenter : IPresenter
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