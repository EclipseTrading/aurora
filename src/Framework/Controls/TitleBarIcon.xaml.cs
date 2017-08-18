using System.Windows;

namespace Aurora.Controls
{
    /// <summary>
    /// Interaction logic for TitleBarIcon.xaml
    /// </summary>
    public partial class TitleBarIcon 
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            "IsActive", typeof(bool), typeof(TitleBarIcon), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            "IsSelected", typeof(bool), typeof(TitleBarIcon), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsTabProperty = DependencyProperty.Register(
            "IsTab", typeof(bool), typeof(TitleBarIcon), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsMouseOverTitleBarProperty = DependencyProperty.Register(
            "IsMouseOverTitleBar", typeof(bool), typeof(TitleBarIcon), new PropertyMetadata(default(bool)));

        public bool IsMouseOverTitleBar
        {
            get { return (bool) GetValue(IsMouseOverTitleBarProperty); }
            set { SetValue(IsMouseOverTitleBarProperty, value); }
        }

        public bool IsActive
        {
            get { return (bool) GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool) GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public bool IsTab
        {
            get { return (bool) GetValue(IsTabProperty); }
            set { SetValue(IsTabProperty, value); }
        }

        public TitleBarIcon()
        {
            InitializeComponent();
        }
    }
}
