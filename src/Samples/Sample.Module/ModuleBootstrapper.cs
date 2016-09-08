using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Commands;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Aurora.Sample.Module.Shared;
using Aurora.Sample.Module.Views.TestWorkspace;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Aurora.Core;
using Newtonsoft.Json.Linq;

namespace Aurora.Sample.Module
{
   
   


    [Module(ModuleName = "SampleModule")]
    public class ModuleBootstrapper : IModule
    {
        private int viewIndex = 0;
        private readonly IActivityService activityService;
        private readonly ICommandBarService commandBarService;
        private readonly IWorkspace currentWorkspace;
       
        private WorkspaceLayout lastSaved;

        public ModuleBootstrapper(IActivityService activityService, ICommandBarService commandBarService, IWorkspace workspace)
        {
            this.activityService = activityService;
            this.commandBarService = commandBarService;
            this.currentWorkspace = workspace;
           
        }

        public async void Initialize()
        {
            

            commandBarService.AddCommand(new CommandInfo("Layout 1"), new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout();
                layout.MainWindowRect = new Rect(500,300, 1200, 800);
                layout.Orientation = DockingOrientation.Horizontal;
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews = { 
                       new DockingViewConfig(typeof(TestWorkspacePresenter), "Main", null, 1, false),
                       new DockingViewConfig(typeof(CustomPresenter), "View1", null, 0, false),
                       new DockingViewConfig(typeof(CustomPresenter), "View4", null, 2, true)
                    },
                    Proportion = 0.3
                });
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews = {
                       new DockingViewConfig(typeof(CustomPresenter), "View2", null, 1, true),
                       new DockingViewConfig(typeof(CustomPresenter), "View3", null, 0, false)
                    },
                    Proportion = 0.7
                });

                await currentWorkspace.LoadLayout(layout);

           

            }));


            commandBarService.AddCommand(new CommandInfo("Layout 2"), new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();

                var layout = new WorkspaceLayout();
                layout.MainWindowRect = new Rect(300, 500, 800, 1200);
                layout.Orientation = DockingOrientation.Vertical;
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews = {
                       new DockingViewConfig(typeof(TestWorkspacePresenter), "Main", null, 0, true),
                    },
                    Proportion = 0.8
                });
                layout.DockGroups.Add(new DockGroupConfig
                {
                    DockingViews = {
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


            commandBarService.AddCommand(new CommandInfo("Close All"), new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();
            }));

            commandBarService.AddCommand(new CommandInfo("Capture"), new DelegateCommand(async () =>
            {
                this.lastSaved = await currentWorkspace.GetCurrentLayout();

            }));

            commandBarService.AddCommand(new CommandInfo("Restore"), new DelegateCommand(async () =>
            {
                await currentWorkspace.CloseAllView();
                await currentWorkspace.LoadLayout(this.lastSaved);
            }));





        }
    }
}
