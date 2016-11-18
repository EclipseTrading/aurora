using System.Diagnostics;
using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestGridPresenter : WorkspaceViewPresenter<TestGridViewModel>
    {
        public TestGridPresenter(IActionHandlerService actionHandlerService) : base(new ViewActivityInfo(null), actionHandlerService)
        {
            Debug.WriteLine("Create TestChildViewPresenter");
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.Title = "Grid view";
        }
    }
}