using Aurora.Core.Container;
using Microsoft.Practices.Prism.Modularity;

namespace $rootnamespace$
{
    public class ModuleBootstrapper : IModule
    {
        private readonly ICommandBarService commandBarService;
        private readonly IActivityService activityService;

        public ModuleBootstrapper(ICommandBarService commandBarService, IActivityService activityService)
        {
            this.commandBarService = commandBarService;
            this.activityService = activityService;
        }

        public void Initialize()
        {
            commandBarService.AddCommand(new CommandInfo("Sample"),
                new Aurora.Core.Commands.StartActivityCommand<SampleActivityInfo>(
                    activityService, () => new SampleActivityInfo("Sample View", isCloseable: true))
                );
        }
    }
}