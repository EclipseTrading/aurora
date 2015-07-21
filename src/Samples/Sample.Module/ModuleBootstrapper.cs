using System;
using Aurora.Core.Commands;
using Aurora.Core.Host;
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
            commandBarService.AddCommand(new CommandInfo("New Sample View"), new StartActivityCommand<SampleViewActivityInfo>(activityService, f));
        }
    }
}
