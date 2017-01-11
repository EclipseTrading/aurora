using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
