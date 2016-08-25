namespace Aurora.Core.Container
{
    public interface IViewManager : IViewContainerService
    {
        void RegisterViewContainerService(HostLocation location, IViewContainerService viewContainerService);
        void SetDefaultViewContainerService(IViewContainerService viewContainerService);
        IViewContainerService GetViewContainerService(HostLocation location);
    }
}