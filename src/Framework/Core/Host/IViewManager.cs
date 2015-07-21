namespace Aurora.Core.Host
{
    public interface IViewManager : IViewHostService
    {
        void RegisterViewHostService(HostLocation location, IViewHostService viewHostService);
        void SetDefaultViewHostService(IViewHostService viewHostService);
    }
}