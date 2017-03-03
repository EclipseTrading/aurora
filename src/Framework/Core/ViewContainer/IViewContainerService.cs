using System.Windows;

namespace Aurora.Core.ViewContainer
{
    public interface IViewContainerService
    {
        void SetTitle(string title);
        void CloseView();    
        void SetHeader(DataTemplate headerTemplate, object headerContent);

    }
}