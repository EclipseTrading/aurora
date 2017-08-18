using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.SyncfusionDockingContainer
{
    public class AuroraProperties
    {
        public static readonly DependencyProperty TitleBarSettingsProperty = DependencyProperty.RegisterAttached("TitleBarSettings", typeof(ITitleBarSettings), typeof(AuroraProperties), 
            new PropertyMetadata(default(ITitleBarSettings)));

        public static ITitleBarSettings GetTitleBarSettings(UIElement element)
        {
            return (ITitleBarSettings) element.GetValue(TitleBarSettingsProperty);
        }

        public static void SetTitleBarSettings(UIElement element, ITitleBarSettings value)
        {
            element.SetValue(TitleBarSettingsProperty, value);
        }
    }
}