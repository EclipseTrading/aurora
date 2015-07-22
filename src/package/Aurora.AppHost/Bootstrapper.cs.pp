using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Aurora.Hosting;
using Microsoft.Practices.Prism.Modularity;

namespace $rootnamespace$
{
    public class Bootstrapper : AuroraBootstrapper
    {
        public override IEnumerable<Type> GetModules()
        {
            yield return typeof(Aurora.DockingHost.ModuleBootstrapper);
        }
    }
}