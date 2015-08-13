using System.Windows;

namespace Aurora.Core.Container
{
    public interface IContainerService
    {
        void SetViewContainer<TView>(HostLocation location, TView view)
            where TView : DependencyObject;
    }
}