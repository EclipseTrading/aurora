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
        public override IEnumerable<Type> GetModules()
        {
            yield return typeof(DockingContainer.ModuleBootstrapper);
            yield return typeof(Sample.Host.ModuleBootstrapper);
            yield return typeof(Sample.Module.ModuleBootstrapper);
        }
    }
}