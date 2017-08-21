using System.Windows;
using Aurora.Core.Container;

namespace Aurora.Controls
{
    public class MenuProperties
    {
        public static readonly DependencyProperty MenuTypeProperty = DependencyProperty.RegisterAttached(
           "MenuType", typeof(MenuType), typeof(MenuProperties), new PropertyMetadata(default(MenuType)));

        public static void SetMenuType(DependencyObject element, MenuType value)
        {
            element.SetValue(MenuTypeProperty, value);
        }

        public static MenuType GetMenuType(DependencyObject element)
        {
            return (MenuType)element.GetValue(MenuTypeProperty);
        }
    }
}