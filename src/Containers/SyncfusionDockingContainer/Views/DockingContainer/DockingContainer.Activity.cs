using Aurora.Core.Activities;
using Aurora.Core.Container;


namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    [ActivityInfo(typeof(DockingContainerActivityInfo))]
    public class DockingContainerActivity : ViewContainerActivity<DockingContainerPresenter, DockingContainerActivityInfo>
    {
        public DockingContainerActivity(DockingContainerActivityInfo activityInfo) : base(activityInfo)
        {
        }

        protected override IViewContainerService CreateViewContainerService()
        {
            return new DockingViewContainerService(ContainerRegionManager);
        }
    }
}
