using System;
using System.Collections.Generic;

namespace Aurora.Core
{
    public interface IModuleProvider
    {
        IEnumerable<Type> GetModules();
    }
}
