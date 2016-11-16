using System;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public interface IDependencyHandler : IHandler
    {
        IDependencyHandler Parent { get; }
        Func<ActionEvent, bool> Delegate { set; }
    }
}