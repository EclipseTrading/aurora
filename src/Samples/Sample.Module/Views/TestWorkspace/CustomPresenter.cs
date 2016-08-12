using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class CustomPresenter : WorkspaceViewPresenter<CustomViewModel>
    {
        public CustomPresenter(ViewActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.JsonString = this.ViewActivityInfo.ViewData?.ToString();
        }

    }
}
