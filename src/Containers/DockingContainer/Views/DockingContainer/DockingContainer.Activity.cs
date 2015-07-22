using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    [ActivityInfo(typeof(DockingContainerActivityInfo))]
    public class DockingContainerActivity : ViewContainerActivity<DockingContainerPresenter, DockingContainerViewModel, DockingContainerView, DockingContainerActivityInfo>
    {
        private readonly IPresenterFactory presenterFactory;

        public DockingContainerActivity(DockingContainerActivityInfo activityInfo, IPresenterFactory presenterFactory) : base(activityInfo)
        {
            this.presenterFactory = presenterFactory;
        }

        protected override IViewContainerService CreateViewContainerService()
        {
            return new DockingViewContainerService(ContainerRegionManager);
        }
    }
}
