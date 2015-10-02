using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Aurora.Hosting
{
    public class CloseOnAction : Behavior<Popup>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(MouseUpHandler));
        }
        
        public void MouseUpHandler(object semder, RoutedEventArgs args)
        {
            this.AssociatedObject.IsOpen = false;
        }
    }
}