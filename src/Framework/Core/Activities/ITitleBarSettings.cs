using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Aurora.Core.Container;

namespace Aurora.Core.Activities
{
    public interface ITitleBarSettings : INotifyPropertyChanged
    {
        ObservableCollection<UIElement> TitleBarControls { get; }
        DataTemplate HeaderTemplate { get; set; }
        object HeaderContent { get; set; }
        FrameworkElement IconContent { get; set; }
        ObservableCollection<CommandBarItem> MenuItems { get; }
        Brush InactiveTabBackground { get; set; }
        Brush InactiveTabIconBackground { get; set; }
        Brush InactiveBackground { get; set; }
        Brush InactiveForeground { get; set; }
        Brush InactiveTabForeground { get; set; }
        Brush ActiveBackground { get; set; }
        Brush ActiveForeground { get; set; }
        Brush ActiveWindowBorder { get; set; }
        Brush InactiveWindowBorder { get; set; }
        Brush InactiveIconForeground { get; set; }
        Brush InactiveIconBackground { get; set; }
        Brush ActiveIconForeground { get; set; }
        Brush ActiveIconBackground { get; set; }
        Brush ButtonAreaBackground { get; set; }
        Thickness InactiveWindowBorderThickness { get; set; }
        Thickness ActiveWindowBorderThickness { get; set; }
    }
}