using System.Windows;
using Aurora.Core;
using Aurora.Core.Host;
using Aurora.DockingHost.Views.DockingHost;
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

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.RegisterType(typeof(IHostService), typeof(DefaultHostService), new ContainerControlledLifetimeManager());
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
