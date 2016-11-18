using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class CustomPresenter : WorkspaceViewPresenter<CustomViewModel>
    {
        public CustomPresenter(ViewActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService) : base(viewActivityInfo, actionHandlerService)
        {
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.JsonString = this.ViewActivityInfo.ViewData?.ToString();
        }

    }
}
