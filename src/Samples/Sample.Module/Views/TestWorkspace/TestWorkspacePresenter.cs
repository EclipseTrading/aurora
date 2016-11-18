using System;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;
using Microsoft.Practices.Prism.Commands;
using Newtonsoft.Json.Linq;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestWorkspacePresenter : WorkspaceViewPresenter<TestWorkspaceViewModel>
    {
        private readonly IWorkspace workspace;
        private IActionService actionService;

        public TestWorkspacePresenter(ViewActivityInfo info, IWorkspace workspace, IActionService actionService, IActionHandlerService actionHandlerService) : base(info, actionHandlerService)
        {
            this.workspace = workspace;
            this.actionService = actionService;
        }

        protected override void OnInitialized()
        {
            var action = actionService.GetAction("action1");
            this.RegisterActionHandler(action, new TestActionHandler("TestWorkspacePresenter"));
        }

        protected override async void OnViewModelChanged()
        {
            this.ViewModel.CreateViewCommand = new DelegateCommand(async () => { await this.CreateView(); });
            this.ViewModel.ToggleOrientationCommand = new DelegateCommand(this.ToogleOrientation);
            this.ViewModel.CloseViewCommand = new DelegateCommand(this.CloseView);
            this.ViewModel.SelectedWindowType = WindowType.Floating;
            this.ViewModel.SelectedViewType = ViewType.Custom;
            this.ViewModel.Title = "Testing";
            this.ViewModel.Width = 800;
            this.ViewModel.Height = 600;

            var input = ViewActivityInfo.ViewData?.ToString();
            this.ViewModel.JsonInput = input ?? "{}";

            var testChildView = await this.AddChildViewAsync(typeof(TestChildPresenter));
            this.ViewModel.TestChildView = testChildView;
        }

        private void ToogleOrientation()
        {
           
        }
        private async Task CreateView()
        {
            if (this.ViewModel.SelectedWindowType == WindowType.Floating)
            {

                var data = JObject.Parse(this.ViewModel.JsonInput);
                this.ViewActivityInfo.ViewData = data;

                var location = new ViewLocation
                {
                    DockState = DockingState.Float,
                    FloatingLeft = this.ViewModel.Left,
                    FloatingTop = this.ViewModel.Top,
                    FloatingWidth = this.ViewModel.Width,
                    FloatingHeight = this.ViewModel.Height
                };
                await
                    this.workspace.CreateView(GetPresenterType(), "id_" + Guid.NewGuid().ToString("N").ToUpper(),
                        this.ViewModel.Title, data, location);
            }
            else
            {
                var data = JObject.Parse(this.ViewModel.JsonInput);
                this.ViewActivityInfo.ViewData = data;

                var location = new ViewLocation
                {
                    DockState = DockingState.Document
                };
                await
                    this.workspace.CreateView(GetPresenterType(), "id_" + Guid.NewGuid().ToString("N").ToUpper(),
                    this.ViewModel.Title, data,
                        location);

            }
        }

        private Type GetPresenterType()
        {
            if (this.ViewModel.SelectedViewType == ViewType.Custom)
                return typeof(CustomPresenter);
            else if (this.ViewModel.SelectedViewType == ViewType.TestWorkspace)
                return typeof(TestWorkspacePresenter);
            else
                return null;
        }


    }
}
