using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;

namespace Aurora.SyncfusionDockingContainer
{
    public class MinimizeOnClick : Behavior<ButtonBase>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Click += MinimizedButtonClicked;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= MinimizedButtonClicked;
        }

        private void MinimizedButtonClicked(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow((DependencyObject)sender) as NativeFloatWindow;
            if (window != null)
            {
                var rect = DockingManager.GetFloatingWindowRect(window.PrimaryElement);
                DockingManager.SetPreviousFloatingWindowRect(window.PrimaryElement, rect);
                window.WindowState = WindowState.Minimized;
            }
        }
    }
}