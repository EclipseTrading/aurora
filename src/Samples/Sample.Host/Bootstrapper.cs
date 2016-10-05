using System;
using System.Collections.Generic;
using Aurora.Hosting;

namespace Aurora.Sample.Host
{
    public class Bootstrapper : AuroraBootstrapper
    {
        public override IEnumerable<Type> GetModules()
        {
            yield return typeof(SyncfusionDockingContainer.ModuleBootstrapper);
            yield return typeof(ModuleBootstrapper);
            yield return typeof(Module.ModuleBootstrapper);
        }
    }
}