using System;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public interface IDependencyHandler : IHandler
    {
        IDependencyHandler Parent { get; }
        void RegisterActionHandler(IAction action, IHandler handler);
    }
}