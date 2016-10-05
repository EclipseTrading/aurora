using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Aurora.Sample.Module.Views.TestWorkspace;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;

namespace Aurora.Sample.Module
{
    [Module(ModuleName = "SampleModule")]
    public class ModuleBootstrapper : IModule
    {
        private readonly ICommandBarService commandBarService;
        private readonly IWorkspace currentWorkspace;

        private WorkspaceLayout lastSaved;

        public ModuleBootstrapper(ICommandBarService commandBarService, IWorkspace workspace)
        {
            this.commandBarService = commandBarService;
            this.currentWorkspace = workspace;
        }

        public void Initialize()
        {

            var layout1 = new MenuItemCommand("Layout 1", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout {MainWindowRect = new Rect(500, 300, 1200, 800)};
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(CustomPresenter), "view1", null)
                {
                    ViewTitle = "Risk and Pnl - Strategy",
                    DockState = DockingState.Dock,
                    DockSide = DockingSide.Left,
                    DockTarget = "",
                    DockWidth = 450,
                    DockHeight = 90,
                    DockIndex = 0
                });
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(CustomPresenter), "view2", null)
                {
                    ViewTitle = "view2",
                    DockState = DockingState.Dock,
                    DockSide = DockingSide.Bottom,
                    DockTarget = "view1",
                    DockWidth = 250,
                    DockHeight = 90,
                    DockIndex = 1
                });
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(CustomPresenter), "view3", null)
                {
                    ViewTitle = "view3",
                    DockState = DockingState.Dock,
                    DockSide = DockingSide.Right,
                    DockTarget = "",
                    DockWidth = 250,
                    DockHeight = 90,
                    DockIndex = 2
                });
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(CustomPresenter), "view4", null)
                {
                    ViewTitle = "view4",
                    DockState = DockingState.Dock,
                    DockSide = DockingSide.Bottom,
                    DockTarget = "",
                    DockWidth = 250,
                    DockHeight = 90,
                    DockIndex = 3
                });
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(TestWorkspacePresenter), "Floating1", null)
                {
                    ViewTitle = "Floating1",
                    DockState = DockingState.Float,
                    FloatingLocation = new Rect(1500, 500, 500, 500)
                });

                await currentWorkspace.LoadLayout(layout);
            }));

            var layout2 = new MenuItemCommand("Layout 2", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout();
                layout.MainWindowRect = new Rect(500, 300, 1200, 800);
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(CustomPresenter), "view1", null)
                {
                    ViewTitle = "Risk and Pnl - Strategy",
                    DockState = DockingState.Dock,
                    DockSide = DockingSide.Left,
                    DockTarget = "",
                    DockWidth = 450,
                    DockHeight = 90,
                    DockIndex = 0
                });
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(CustomPresenter), "Floating1", null)
                {
                    ViewTitle = "Floating1",
                    DockState = DockingState.Float,
                    FloatingLocation = new Rect(1500, 500, 500, 500)
                });

                await currentWorkspace.LoadLayout(layout);
            }));

            var closeAll = new MenuItemCommand("Close All", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();
            }));

            var capture = new MenuItemCommand("Capture", new DelegateCommand(async () =>
            {
                this.lastSaved = await currentWorkspace.GetCurrentLayout();

            }));

            var restore = new MenuItemCommand("Restore", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();
                await currentWorkspace.LoadLayout(this.lastSaved);
            }));

            var workspaces = new MenuItemCommand("Workspaces", null,
                m => Task.Delay(1000).ContinueWith(t => new CommandBarItem[]
                {
                    layout1, layout2, new DividerItem(), closeAll, capture, restore
                }));

            commandBarService.AddCommand(workspaces);


            var nested = new MenuItemCommand("Nested",
                new MenuItemCommand("SubItem1" ,
                    new MenuItemCommand("SubSubItem1"),
                    new MenuItemCommand("SubSubItem2")) { IconPath = "../Image/config.png"},
                new MenuItemCommand("SubItem2" ,
                    new MenuItemCommand("SubSubItem3"),
                    new MenuItemCommand("SubSubItem4")));

            commandBarService.AddCommand(nested);

        }
    }
}
