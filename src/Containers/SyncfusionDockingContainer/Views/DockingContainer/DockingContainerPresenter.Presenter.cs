using Aurora.Core;

namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    public class DockingContainerPresenter : Presenter<DockingContainerViewModel, DockingContainerActivityInfo>
    {
        public DockingContainerPresenter(DockingContainerActivityInfo viewActivityInfo, IDependencyHandler dependencyHandler) : base(viewActivityInfo, dependencyHandler)
        {
        }
    }
}
