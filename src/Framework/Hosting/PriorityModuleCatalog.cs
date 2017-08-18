using System;
using System.Collections.Generic;
using System.Linq;
using Aurora.Core.Container;
using Prism.Modularity;

namespace Aurora.Hosting
{
    public class PriorityModuleCatalog : ModuleCatalog
    {
        protected override IEnumerable<ModuleInfo> Sort(IEnumerable<ModuleInfo> modules)
        {
            var moduleTypes = modules.Select(m => new
            {
                Priority = GetPriority(Type.GetType(m.ModuleType)),
                Module = m
            });

            return moduleTypes.OrderBy(t => t.Priority).Select(mt => mt.Module);

        }

        private static Priority GetPriority(Type type)
        {
            var attr = type.GetCustomAttributes(typeof(ModulePriorityAttribute), true).OfType<ModulePriorityAttribute>().FirstOrDefault();
            return attr?.Priority ?? Priority.Application;
        }
    }
}