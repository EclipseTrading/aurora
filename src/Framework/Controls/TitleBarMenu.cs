using System.Windows;
using System.Windows.Controls;

namespace Aurora.Controls
{
    public class TitleBarMenu : ContentControl
    {
        public static readonly DependencyProperty IsTabProperty = DependencyProperty.Register("IsTab", typeof(bool), typeof(TitleBarMenu), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(TitleBarMenu), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(TitleBarMenu), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsMouseOverTitleBarProperty = DependencyProperty.Register("IsMouseOverTitleBar", typeof(bool), typeof(TitleBarMenu), new PropertyMetadata(default(bool)));

        public bool IsTab
        {
            get { return (bool) GetValue(IsTabProperty); }
            set { SetValue(IsTabProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool) GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public bool IsActive
        {
            get { return (bool) GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public bool IsMouseOverTitleBar
        {
            get { return (bool) GetValue(IsMouseOverTitleBarProperty); }
            set { SetValue(IsMouseOverTitleBarProperty, value); }
        }
    }
}
