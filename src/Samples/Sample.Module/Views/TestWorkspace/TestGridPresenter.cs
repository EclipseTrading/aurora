using System.Diagnostics;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestGridPresenter : WorkspaceViewPresenter<TestGridViewModel>
    {
        public TestGridPresenter(IDependencyHandler dependencyHandler) : base(new ViewActivityInfo(null), dependencyHandler)
        {
            Debug.WriteLine("Create TestChildViewPresenter");
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.Title = "Grid view";
        }
    }
}