using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Modularity;

namespace Aurora.Core
{
    public class DefaultModuleProvider : IModuleProvider
    {
        public IEnumerable<Type> GetModules()
        {
            var modules = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof (IModule).IsAssignableFrom(t));
            return modules;
        }
    }
}