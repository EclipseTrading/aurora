using Aurora.Core.Actions;
using Aurora.Core.Activities;

namespace Aurora.Core.Workspace
{
    public class WorkspaceViewPresenter<TViewModel> : ViewPresenter<TViewModel, ViewActivityInfo>
        where TViewModel : IViewModel
    {
        public WorkspaceViewPresenter(ViewActivityInfo info, IActionHandlerService actionHandlerService) : base(info, actionHandlerService)
        {

        }
    }
}
