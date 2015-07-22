using System;

namespace Aurora.Core.Container
{
    public interface ICommandBarServiceHost : ICommandBarService, IDisposable
    {
        void RegisterCommandBarService(string barName, ICommandBarService commandBarService);
        void RegisterDefaultCommandBarService(ICommandBarService commandBarService);
    }
}