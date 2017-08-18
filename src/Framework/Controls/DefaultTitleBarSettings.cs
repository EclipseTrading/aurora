using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.Controls
{
    public class DefaultTitleBarSettings : ITitleBarSettings
    {
        public DefaultTitleBarSettings()
        {
            this.IconContent = new TitleBarIcon
            {
                DataContext = this
            };

            this.IconContent.Loaded += IconContent_Loaded;
        }


        private static readonly Brush DefaultActiveTitleBarBrush = new SolidColorBrush(Color.FromArgb(255, 17, 158, 218));
        private static readonly Brush DefaultInactiveTitleBarBrush = new SolidColorBrush(Color.FromArgb(255, 235, 235, 235));
        private static readonly Brush DefaultInactiveWindowBorderBrush = new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));
        private static readonly Brush DefaultAactiveWindowBorderBrush = new SolidColorBrush(Color.FromArgb(255, 70, 200, 245));

        private object headerContent;

        private DataTemplate headerTemplate;
        private Brush inactiveBackground = DefaultInactiveTitleBarBrush;
        private Brush inactiveIconBackground = DefaultInactiveTitleBarBrush;
        private Brush inactiveTabBackground = DefaultInactiveTitleBarBrush;
        private Brush inactiveTabIconBackground = DefaultInactiveTitleBarBrush;
        private Brush inactiveForeground = Brushes.Black;
        private Brush inactiveIconForeground = DefaultInactiveTitleBarBrush;
        private Brush inactiveTabForeground = Brushes.Black;
        private Brush inactiveWindowBorder = DefaultInactiveWindowBorderBrush;
        private Thickness inactiveWindowBorderThickness = new Thickness(1);

        private Brush activeBackground = DefaultActiveTitleBarBrush;
        private Brush activeForeground = Brushes.White;
        private Brush activeIconBackground = DefaultActiveTitleBarBrush;
        private Brush activeIconForeground = Brushes.White;
        private Brush activeWindowBorder = DefaultAactiveWindowBorderBrush;
        private Thickness activeWindowBorderThickness = new Thickness(1);
        private Brush buttonAreaBackground = Brushes.Transparent;

        private FrameworkElement iconContent;

        public DefaultTitleBarSettings(FrameworkElement iconContent)
        {
            this.iconContent = iconContent;
        }

        public ObservableCollection<UIElement> TitleBarControls { get; } = new ObservableCollection<UIElement>();

        public DataTemplate HeaderTemplate
        {
            get { return headerTemplate; }
            set
            {
                headerTemplate = value;
                this.OnPropertyChanged();
            }
        }

        public object HeaderContent
        {
            get { return headerContent; }
            set
            {
                headerContent = value;
                this.OnPropertyChanged();
            }
        }

        public FrameworkElement IconContent
        {
            get { return iconContent; }
            set
            {
                iconContent = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<CommandBarItem> MenuItems { get; } = new ObservableCollection<CommandBarItem>();

        public Brush InactiveTabBackground
        {
            get { return inactiveTabBackground; }
            set
            {
                inactiveTabBackground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveTabIconBackground
        {
            get { return inactiveTabIconBackground; }
            set
            {
                inactiveTabIconBackground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveBackground
        {
            get { return inactiveBackground; }
            set
            {
                inactiveBackground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveForeground
        {
            get { return inactiveForeground; }
            set
            {
                inactiveForeground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveTabForeground
        {
            get { return inactiveTabForeground; }
            set
            {
                inactiveTabForeground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush ActiveBackground
        {
            get { return activeBackground; }
            set
            {
                activeBackground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush ActiveForeground
        {
            get { return activeForeground; }
            set
            {
                activeForeground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush ActiveWindowBorder
        {
            get { return activeWindowBorder; }
            set
            {
                activeWindowBorder = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveWindowBorder
        {
            get { return inactiveWindowBorder; }
            set
            {
                inactiveWindowBorder = value;
                this.OnPropertyChanged();
            }
        }

        public Thickness InactiveWindowBorderThickness
        {
            get { return inactiveWindowBorderThickness; }
            set
            {
                inactiveWindowBorderThickness = value;
                this.OnPropertyChanged();
            }
        }

        public Thickness ActiveWindowBorderThickness
        {
            get { return activeWindowBorderThickness; }
            set
            {
                activeWindowBorderThickness = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveIconForeground
        {
            get { return inactiveIconForeground; }
            set
            {
                inactiveIconForeground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush InactiveIconBackground
        {
            get { return inactiveIconBackground; }
            set
            {
                inactiveIconBackground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush ActiveIconForeground
        {
            get { return activeIconForeground; }
            set
            {
                activeIconForeground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush ActiveIconBackground
        {
            get { return activeIconBackground; }
            set
            {
                activeIconBackground = value;
                this.OnPropertyChanged();
            }
        }

        public Brush ButtonAreaBackground
        {
            get { return buttonAreaBackground; }
            set
            {
                buttonAreaBackground = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void IconContent_Loaded(object sender, RoutedEventArgs e)
        {
            this.IconContent.SetBinding(TitleBarIcon.IsActiveProperty, CreateBinding("IsActive"));
            this.IconContent.SetBinding(TitleBarIcon.IsSelectedProperty, CreateBinding("IsSelected"));
            this.IconContent.SetBinding(TitleBarIcon.IsTabProperty, CreateBinding("IsTab"));
            this.IconContent.SetBinding(TitleBarIcon.IsMouseOverTitleBarProperty, CreateBinding("IsMouseOverTitleBar"));
        }

        private Binding CreateBinding(string property)
        {
            return new Binding
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(TitleBarMenu), 1),
                Path = new PropertyPath(property)
            };
        }
    }
}
