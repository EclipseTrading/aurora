using System;
using System.Windows;
using Aurora.Controls;
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

    public class CustomPresenter : WorkspaceViewPresenter<CustomViewModel>, IHostWindowManager
    {
        public CustomPresenter(ViewActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService) : base(viewActivityInfo, actionHandlerService)
        {
        }


        protected override void OnInitialized()
        {
            var headerTemplate = (DataTemplate)this.ContentContext.MainContent.TryFindResource("SampleHeaderTemplate");
            TitleBarSettings.HeaderContent = this.ViewActivityInfo.Title;
            TitleBarSettings.HeaderTemplate = headerTemplate;
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.JsonString = this.ViewActivityInfo.ViewData?.ToString();
        }

        public ITitleBarSettings TitleBarSettings { get;  } =  new DefaultTitleBarSettings();
        public Action CloseAction { get; set; }
    }
}
