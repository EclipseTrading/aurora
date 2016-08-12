using System;
using Aurora.Core.Commands;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Aurora.Sample.Module.Shared;
using Aurora.Sample.Module.Views.TestWorkspace;
using Microsoft.Practices.Prism.Modularity;

namespace Aurora.Sample.Module
{
    [Module(ModuleName = "SampleModule")]
    public class ModuleBootstrapper : IModule
    {
        private int viewIndex = 0;
        private readonly IActivityService activityService;
        private readonly ICommandBarService commandBarService;
        private readonly IWorkspaceManager workspaceManager;

        public ModuleBootstrapper(IActivityService activityService, ICommandBarService commandBarService, IWorkspaceManager workspaceManager)
        {
            this.activityService = activityService;
            this.commandBarService = commandBarService;
            this.workspaceManager = workspaceManager;
        }

        public async void Initialize()
        {
            Func<SampleViewActivityInfo> f = () => new SampleViewActivityInfo("Sample View" + (viewIndex != 0 ? " (" + viewIndex++ + ")" : ""), isCloseable: true)
            {
                MessageFormat = "Hello {0}"
            };
            commandBarService.AddCommand(new CommandInfo("New Sample View") { Description = "test", IconPath= "pack://application:,,,/Aurora.CommandBarContainer;component/Image/config.png" }, new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
         
            var location = new WorkspaceLocation()
            {
                IsFloating = false,
                GroupIdx = 0,
                TabOrder = 0,
                IsSelected = false
            };
            await this.workspaceManager.CurrentWorkspace.CreateView(typeof(TestWorkspacePresenter), "Main", location, null);


        }
    }
}
