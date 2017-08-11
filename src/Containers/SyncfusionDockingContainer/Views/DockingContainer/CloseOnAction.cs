using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using Syncfusion.Windows.Shared;

namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    public class CloseOnAction : Behavior<Popup>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.AddHandler(MenuItemAdv.ClickEvent, new RoutedEventHandler(MouseUpHandler));
        }
        
        public void MouseUpHandler(object semder, RoutedEventArgs args)
        {
            this.AssociatedObject.IsOpen = false;
        }
    }
}