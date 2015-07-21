using System.Windows;
using System.Windows.Interactivity;

namespace Aurora.Hosting
{
    public class DragWindowBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            var parent = Window.GetWindow(AssociatedObject);

            if (parent != null)
            {
                AssociatedObject.MouseLeftButtonDown += (s, e) => parent.DragMove();
            }
        }
    }
}