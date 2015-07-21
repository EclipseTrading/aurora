using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Aurora.Hosting;
using Microsoft.Practices.Prism.Modularity;

namespace Aurora.Sample.Host
{
    public class Bootstrapper : AuroraBootstrapper
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

        public IEnumerable<Type> GetModules()
        {
            yield return typeof(DockingHost.ModuleBootstrapper);
            yield return typeof(Sample.Host.ModuleBootstrapper);
            yield return typeof(Sample.Module.ModuleBootstrapper);
        }
    }
}