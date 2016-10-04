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

                var layout = new WorkspaceLayout
                {
                    MainWindowRect = new Rect(500, 300, 1200, 800),
                    Orientation = DockingOrientation.Horizontal
                };
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews =
                    {
                        new DockingViewConfig(typeof(TestWorkspacePresenter), "Main", null, 1, false),
                        new DockingViewConfig(typeof(CustomPresenter), "View1", null, 0, false),
                        new DockingViewConfig(typeof(CustomPresenter), "View4", null, 2, true)
                    },
                    Proportion = 0.3
                });
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews =
                    {
                        new DockingViewConfig(typeof(CustomPresenter), "View2", null, 1, true),
                        new DockingViewConfig(typeof(CustomPresenter), "View3", null, 0, false)
                    },
                    Proportion = 0.7
                });

                await currentWorkspace.LoadLayout(layout);
            }));

            var layout2 = new MenuItemCommand("Layout 2", new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout
                {
                    MainWindowRect = new Rect(300, 500, 800, 1200),
                    Orientation = DockingOrientation.Vertical
                };
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews =
                    {
                        new DockingViewConfig(typeof(TestWorkspacePresenter), "Main", null, 0, true),
                    },
                    Proportion = 0.8
                });
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews =
                    {
                        new DockingViewConfig(typeof(CustomPresenter), "View2", null, 0, false),
                        new DockingViewConfig(typeof(CustomPresenter), "View3", null, 2, true),
                        new DockingViewConfig(typeof(CustomPresenter), "View4", null, 1, false)
                    },
                    Proportion = 0.2
                });
                layout.FloatingViews.Add(new FloatingViewConfig(typeof(CustomPresenter), "Floating1", null,
                    new Rect(1500, 500, 500, 500)));

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

        //    commandBarService.AddCommand(workspaces);


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
