using System.Windows;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public static class ViewPropertyHelper
    {
        public static readonly DependencyProperty ActionHandlerServiceProperty = DependencyProperty.RegisterAttached(
           "ActionHandlerService", typeof(IActionHandlerService), typeof(ViewPropertyHelper), new PropertyMetadata(default(IActionHandlerService)));

        public static void SetActionHandlerService(DependencyObject element, IActionHandlerService value)
        {
            element.SetValue(ActionHandlerServiceProperty, value);
        }

        public static IActionHandlerService GetActionHandlerService(DependencyObject element)
        {
            return (IActionHandlerService)element.GetValue(ActionHandlerServiceProperty);
        }
    }
}
