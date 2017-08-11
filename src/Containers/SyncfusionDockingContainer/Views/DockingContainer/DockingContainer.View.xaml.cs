using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;

namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    /// <summary>
    /// Interaction logic for DockingContainer.xaml
    /// </summary>
    public partial class DockingContainerView : UserControl
    {
        public DockingContainerView()
        {
            InitializeComponent();
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
