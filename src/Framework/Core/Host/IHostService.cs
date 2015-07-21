using System.Windows;

namespace Aurora.Core.Host
{
    public interface IHostService
    {
        void SetViewHost<TView>(HostLocation location, TView view)
            where TView : FrameworkElement;
    }
}