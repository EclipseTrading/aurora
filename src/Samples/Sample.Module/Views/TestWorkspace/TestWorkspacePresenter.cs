using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Aurora.Controls;
using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Newtonsoft.Json.Linq;
using Prism.Commands;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestWorkspacePresenter : WorkspaceViewPresenter<TestWorkspaceViewModel>, IHostWindowManager
    {
        private readonly IWorkspace workspace;
        private readonly IActionService actionService;

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
            this.TitleBarSettings.MenuItems.Add(
                new MenuItemCommand("Test Menu Item")
                {
                    Icon = new Ellipse { Width = 10, Height = 10, Fill = Brushes.Blue }
                });
            this.TitleBarSettings.TitleBarControls.Add(new Ellipse { Width = 10, Height = 10, Fill = Brushes.Blue, Margin = new Thickness(7.5, 0, 7.5, 0)});
            this.TitleBarSettings.ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 17, 218, 158));
            this.TitleBarSettings.ActiveForeground = Brushes.White;
            this.TitleBarSettings.InactiveForeground = Brushes.White;
            this.TitleBarSettings.InactiveTabForeground = Brushes.Black;
            this.TitleBarSettings.ActiveIconBackground = this.TitleBarSettings.ActiveBackground;
            this.TitleBarSettings.InactiveIconBackground = this.TitleBarSettings.ActiveBackground;
            this.TitleBarSettings.InactiveBackground = this.TitleBarSettings.ActiveBackground;
            this.TitleBarSettings.ActiveWindowBorder = this.TitleBarSettings.ActiveBackground;
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

        public void CloseView()
        {
            CloseAction?.Invoke();
        }

        public ITitleBarSettings TitleBarSettings { get; } = new DefaultTitleBarSettings();
        public Action CloseAction { get; set; }
    }
}
