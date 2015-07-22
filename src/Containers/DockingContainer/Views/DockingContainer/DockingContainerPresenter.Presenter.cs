using Aurora.Core;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class DockingContainerPresenter : Presenter<DockingContainerViewModel, DockingContainerView, DockingContainerActivityInfo>
    {
        public DockingContainerPresenter(DockingContainerActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }
}
