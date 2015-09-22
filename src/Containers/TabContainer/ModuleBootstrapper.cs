using Aurora.Core.Container;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace Aurora.TabContainer
{
    [Module(ModuleName = "TabContainer")]
    public class ModuleBootstrapper : IModule
    {
        private readonly IUnityContainer container;

        public ModuleBootstrapper(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterType(typeof (IViewContainerService), typeof (TabViewContainerService));
        }
    }
}
