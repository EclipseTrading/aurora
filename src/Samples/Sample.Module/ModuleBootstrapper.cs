using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Aurora.Core;
using Aurora.Core.Actions;
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
        private IActionService actionService;
        private IHandlerService handlerSerbice;
        private IBindingService bindingService;

        public ModuleBootstrapper(ICommandBarService commandBarService, IWorkspace workspace, IActionService actionService, IHandlerService handlerService, IBindingService bindingService)
        {
            this.commandBarService = commandBarService;
            this.currentWorkspace = workspace;
            this.actionService = actionService;
            this.handlerSerbice = handlerService;
            this.bindingService = bindingService;
        }

        public void Initialize()
        {

            var layout1 = new MenuItemCommand("Layout 1", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout { MainWindowRect = new Rect(500, 300, 1200, 800) };
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

            var layout3 = new MenuItemCommand("Test Layout", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout {MainWindowRect = new Rect(500, 300, 1200, 800)};
                layout.WorkspaceViews.Add(new WorkspaceViewConfig(typeof(TestWorkspacePresenter), "Floating1", null)
                {
                    ViewTitle = "Floating1",
                    DockState = DockingState.Float,
                    FloatingLocation = new Rect(1500, 500, 500, 500)
                });

                await currentWorkspace.LoadLayout(layout);
            }));


            var workspaces = new MenuItemCommand("Workspaces", null,
                m => Task.Delay(1000).ContinueWith(t => new CommandBarItem[]
                {
                    layout1, layout2, layout3, new DividerItem(), closeAll, capture, restore
                }));

            commandBarService.AddCommand(workspaces);


            var cmdItem =  new MenuItemCommand("New View", new DelegateCommand(async () =>
            {
                var location = new ViewLocation
                {
                    DockState = DockingState.Document
                };
                await this.currentWorkspace.CreateView(typeof(TestWorkspacePresenter),
                        "id_" + Guid.NewGuid().ToString("N").ToUpper(),
                        "Define new Layout", null,
                        location);

            }))
            {
                IconPath = "pack://application:,,,/Images/new_window.png",
                Description = null
            };
            commandBarService.AddCommand(cmdItem);

            cmdItem = new MenuItemCommand("New child View", new DelegateCommand(async () =>
            {
                var location = new ViewLocation
                {
                    DockState = DockingState.Document
                };
                await this.currentWorkspace.CreateView(typeof(TestChildPresenter),
                    "id_" + Guid.NewGuid().ToString("N").ToUpper(),
                    "Define new Layout", null,
                    location);

            }));
            commandBarService.AddCommand(cmdItem);

            cmdItem = new MenuItemCommand("New grid View", new DelegateCommand(async () =>
            {
                var location = new ViewLocation
                {
                    DockState = DockingState.Document
                };
                await this.currentWorkspace.CreateView(typeof(TestGridPresenter),
                        "id_" + Guid.NewGuid().ToString("N").ToUpper(),
                        "Define new Layout", null,
                        location);

            }));
            commandBarService.AddCommand(cmdItem);


            var action = new DefaultAction("action1");
            actionService.RegisterAction(action);
            handlerSerbice.RegisterHandler(action, new TestHandler());
            bindingService.RegisterBinding(new KeyStroke(Key.L, true), action);

            var nested = new MenuItemCommand("Nested",
                new MenuItemCommand("SubItem1",
                    new MenuItemCommand("SubSubItem1"),
                    new MenuItemCommand("SubSubItem2"))
                { IconPath = "../Image/config.png" },
                new MenuItemCommand("SubItem2",
                    new MenuItemCommand("SubSubItem3"),
                    new MenuItemCommand("SubSubItem4")));

            commandBarService.AddCommand(nested);

        }
    }

    public class TestHandler : IHandler
    {
        public bool Execute(ActionEvent evt)
        {
            MessageBox.Show(evt.EvtCtx.ActiveWindow, $"Handled by module-registered handler: {evt.EvtCtx}");
            return true;
        }
    }
}
