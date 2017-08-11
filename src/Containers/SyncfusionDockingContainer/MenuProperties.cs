using System.Windows;

namespace Aurora.SyncfusionDockingContainer
{
    public class MenuProperties
    {
        public static readonly DependencyProperty IsTabProperty = DependencyProperty.RegisterAttached(
            "IsTab", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached(
            "IsSelected", typeof(bool), typeof(MenuProperties), new PropertyMetadata(default(bool)));

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

    }
}