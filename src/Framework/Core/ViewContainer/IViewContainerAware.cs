namespace Aurora.Core.ViewContainer
{
    public interface IViewContainerAware
    {
        IViewContainerService ViewContainerService { get; set; }
    }
}
