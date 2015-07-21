using System;

namespace Aurora.Core.Host
{
    public interface ICommandBarServiceHost : ICommandBarService, IDisposable
    {
        void RegisterCommandBarService(string barName, ICommandBarService commandBarService);
        void RegisterDefaultCommandBarService(ICommandBarService commandBarService);
    }
}