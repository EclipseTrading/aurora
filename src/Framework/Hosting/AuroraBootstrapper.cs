using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Container;
using Aurora.DockingContainer.Views.DockingContainer;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Xceed.Wpf.AvalonDock;
using ContainerControlledLifetimeManager = Microsoft.Practices.Unity.ContainerControlledLifetimeManager;
using Microsoft.Practices.Unity;

namespace Aurora.Hosting
{
    public class AuroraBootstrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            var shell = new Shell();

            Application.Current.MainWindow = shell;
            shell.Show();

            return shell;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new PriorityModuleCatalog();

            foreach (var type in GetModules())
            {
                var attr = type.GetCustomAttributes(typeof(ModuleAttribute), true)
                    .OfType<ModuleAttribute>()
                    .FirstOrDefault()
                           ?? new ModuleAttribute { ModuleName = type.AssemblyQualifiedName, OnDemand = false };

                catalog.AddModule(attr.ModuleName,
                    type.AssemblyQualifiedName,
                    attr.OnDemand ? InitializationMode.OnDemand : InitializationMode.WhenAvailable);
            }

            return catalog;
        }

        public virtual IEnumerable<Type> GetModules()
        {
            yield break;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.RegisterType(typeof(IContainerService), typeof(DefaultContainerService), new ContainerControlledLifetimeManager());
            this.Container.RegisterType(typeof(IActivityService), typeof(DefaultActivityService), new ContainerControlledLifetimeManager());
            this.Container.RegisterType(typeof(IPresenterFactory), typeof(PresenterFactory), new ContainerControlledLifetimeManager());
            this.Container.RegisterType(typeof(IViewManager), typeof(DefaultViewManager), new ContainerControlledLifetimeManager());

            var commandBarServiceHost = new DefaultCommandBarServiceHost();

            this.Container.RegisterInstance<ICommandBarServiceHost>(commandBarServiceHost);
            this.Container.RegisterInstance<ICommandBarService>(commandBarServiceHost);
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings == null)
                return null;
            

            mappings.RegisterMapping(typeof(DockingManager), this.Container.Resolve<AvalonDockRegionAdapter>());

            return mappings;
        }
    }
}
