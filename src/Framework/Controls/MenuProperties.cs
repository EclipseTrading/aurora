using System.Windows;
using Aurora.Core.Container;

namespace Aurora.Controls
{
    public class MenuProperties
    {
        public static readonly DependencyProperty IsTabProperty = DependencyProperty.RegisterAttached(
            "IsTab", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached(
            "IsSelected", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsMouseOverProperty = DependencyProperty.RegisterAttached(
            "IsMouseOver", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

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

        public static void SetIsSelected(DependencyObject element, bool value)
        {
            element.SetValue(IsSelectedProperty, value);
        }

        public static bool GetIsSelected(DependencyObject element)
        {
            return (bool) element.GetValue(IsSelectedProperty);
        }

        public static void SetIsActive(DependencyObject element, bool value)
        {
            element.SetValue(IsActiveProperty, value);
        }

        public static bool GetIsActive(DependencyObject element)
        {
            return (bool) element.GetValue(IsActiveProperty);
        }

        public static void SetIsTab(DependencyObject element, bool value)
        {
            element.SetValue(IsTabProperty, value);
        }

        public static bool GetIsTab(DependencyObject element)
        {
            return (bool) element.GetValue(IsTabProperty);
        }

        public static bool GetIsMouseOver(UIElement element)
        {
            return (bool) element.GetValue(IsMouseOverProperty);
        }

        public static void SetIsMouseOver(UIElement element, bool value)
        {
            element.SetValue(IsMouseOverProperty, value);
        }
    }
}