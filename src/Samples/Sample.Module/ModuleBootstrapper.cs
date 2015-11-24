using System;
using Aurora.Core.Commands;
using Aurora.Core.Container;
using Aurora.Sample.Module.Shared;
using Microsoft.Practices.Prism.Modularity;

namespace Aurora.Sample.Module
{
    [Module(ModuleName = "SampleModule")]
    public class ModuleBootstrapper : IModule
    {
        private int viewIndex = 0;
        private readonly IActivityService activityService;
        private readonly ICommandBarService commandBarService;

        public ModuleBootstrapper(IActivityService activityService, ICommandBarService commandBarService)
        {
            this.activityService = activityService;
            this.commandBarService = commandBarService;
        }

        public async void Initialize()
        {
            Func<SampleViewActivityInfo> f = () => new SampleViewActivityInfo("Sample View" + (viewIndex != 0 ? " (" + viewIndex++ + ")" : ""), isCloseable: true)
            {
                MessageFormat = "Hello {0}"
            };

            await activityService.StartActivityAsync(f());
            commandBarService.AddCommand(new CommandInfo("New Sample View") { Description = "test", IconPath= "pack://application:,,,/Aurora.CommandBarContainer;component/Image/config.png" }, new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
            commandBarService.AddCommand(new CommandInfo("View2") { Description = "hello view", IconPath = "pack://application:,,,/Aurora.CommandBarContainer;component/Image/limits.png" }, new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
            commandBarService.AddCommand(new CommandInfo("View3") { Description = "test", IconPath = "pack://application:,,,/Aurora.CommandBarContainer;component/Image/config.png" }, new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
            commandBarService.AddCommand(new CommandInfo("View4") { Description = "test", IconPath = "pack://application:,,,/Aurora.CommandBarContainer;component/Image/config.png" }, new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
            commandBarService.AddCommand(new CommandInfo("View5") { Description = "", IconPath = "pack://application:,,,/Aurora.CommandBarContainer;component/Image/limits.png" }, new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
         
        }
    }
}
