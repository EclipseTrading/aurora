using System;
using System.Collections.Generic;
using Aurora.Hosting;

namespace $rootnamespace$
{
    public class Bootstrapper : AuroraBootstrapper
    {
        public override IEnumerable<Type> GetModules()
        {
            yield return typeof(Aurora.DockingContainer.ModuleBootstrapper);			
            yield return typeof (ModuleBootstrapper);
        }
    }
}