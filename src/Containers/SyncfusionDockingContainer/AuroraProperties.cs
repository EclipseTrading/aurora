using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.SyncfusionDockingContainer
{
    public class AuroraProperties
    {
        public static readonly DependencyProperty TitleBarSettingsProperty = DependencyProperty.RegisterAttached("TitleBarSettings", typeof(TitleBarSettings), typeof(AuroraProperties), 
            new PropertyMetadata(default(TitleBarSettings)));

        public static TitleBarSettings GetTitleBarSettings(UIElement element)
        {
            return (TitleBarSettings) element.GetValue(TitleBarSettingsProperty);
        }

        public static void SetTitleBarSettings(UIElement element, TitleBarSettings value)
        {
            element.SetValue(TitleBarSettingsProperty, value);
        }
    }
}