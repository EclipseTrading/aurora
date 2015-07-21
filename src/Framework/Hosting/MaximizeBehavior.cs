using System.Windows;
using System.Windows.Interactivity;

namespace Aurora.Hosting
{
    public class MaximizeBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            var w = Window.GetWindow(this.AssociatedObject);

            if (w != null)
            {
                w.MouseDoubleClick +=
                    (s, e) => w.WindowState = w.WindowState == WindowState.Maximized
                        ? WindowState.Normal
                        : WindowState.Maximized;
            }
        }
    }
}