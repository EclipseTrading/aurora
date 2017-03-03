using System.Windows;
using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class SampleHeaderContent
    {
        public string Title { get; set; }
    }

    public class CustomPresenter : WorkspaceViewPresenter<CustomViewModel>
    {
        public CustomPresenter(ViewActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService) : base(viewActivityInfo, actionHandlerService)
        {
        }


        protected override void OnInitialized()
        {
            var headerTemplate = (DataTemplate)this.ContentContext.MainContent.TryFindResource("SampleHeaderTemplate");
            this.ViewActivityInfo.HeaderTemplate = headerTemplate;
            this.ViewActivityInfo.HeaderContent = new SampleHeaderContent
            {
                Title = this.ViewActivityInfo.Title
            };

        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.JsonString = this.ViewActivityInfo.ViewData?.ToString();
        }

    }
}
