using Aurora.Core;
using Aurora.Core.Actions;

namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    public class DockingContainerPresenter : Presenter<DockingContainerViewModel, DockingContainerActivityInfo>
    {
        public DockingContainerPresenter(DockingContainerActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService) : base(viewActivityInfo, actionHandlerService)
        {
        }
    }
}
