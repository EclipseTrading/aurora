using Aurora.Core.Host;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace Aurora.TabHost
{
    [Module(ModuleName = "TabHost")]
    public class ModuleBootstrapper : IModule
    {
        private readonly IUnityContainer container;

        public ModuleBootstrapper(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterType(typeof (IViewHostService), typeof (TabViewHostService));
        }
    }
}
