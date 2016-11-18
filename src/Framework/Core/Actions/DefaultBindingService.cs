using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Aurora.Core.ViewContainer;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Tools.Controls;

namespace Aurora.Core.Actions
{
    public class DefaultBindingService : IBindingService
    {
        private readonly Dictionary<KeyStroke, IAction> keyStrokeToActionIdMap = new Dictionary<KeyStroke, IAction>();
        private readonly RootDependencyHandler rootHandler;

        public DefaultBindingService(IHandlerService handlerService)
        {
            this.rootHandler = new RootDependencyHandler(handlerService);
            new KeyDownListener(Application.Current, Dispatch);
        }

        private void Dispatch(KeyEventArgs evt)
        {
            if (IsRejectedKey(evt))
            {
                return;
            }

            var keyStroke = new KeyStroke(evt);
            Console.WriteLine($"Dispatch key: {keyStroke}");

            IAction action;
            if (!keyStrokeToActionIdMap.TryGetValue(keyStroke, out action))
            {
                return;
            }

            var ctx = CreateEventContext();
            var handled = GetActionHandler(ctx)?.Execute(new ActionEvent(action, ctx));
            if(handled.GetValueOrDefault())
            {
                evt.Handled = true;
            }
        }

        private IDependencyHandler GetActionHandler(IEventContext ctx)
        {
            var depObj = ctx.ActiveElement as DependencyObject;
            if (depObj == null)
            {
                // No active selected element
                return rootHandler;
            }
                 
            var i = 0;
            // Recursively find handler along element tree upward
            while (depObj != null)
            {
                var handler = ViewPropertyHelper.GetDependencyHandler(depObj);
                Debug.WriteLine($"DefBindingService - find parent element: {i}: {depObj}:handler={handler}");
                if (handler != null)
                {
                    // Remove handler found from selected element
                    return handler;
                }

                depObj = LogicalTreeHelper.GetParent(depObj);
                i++;
            }

            return rootHandler;
        }
        

        private static bool IsRejectedKey(KeyEventArgs evt)
        {
            switch (evt.RealKey())
            {
                case Key.LeftShift:
                case Key.RightShift:
                case Key.LeftCtrl:
                case Key.RightCtrl:
                case Key.LeftAlt:
                case Key.RightAlt:
                    return true;
                default:
                    return false;
            }
        }

        private static IEventContext CreateEventContext()
        {
            return new DefaultEventContext(
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive),
                Keyboard.FocusedElement,
                Keyboard.FocusedElement
                );
        }

        public void RegisterBinding(KeyStroke keyStroke, IAction action)
        {
            keyStrokeToActionIdMap.Add(keyStroke, action);
            Debug.WriteLine($"Registered binding[{keyStroke}] for action[{action.Id}] - {keyStrokeToActionIdMap.Count} bindings");
        }

        public void UnregisterBinding(KeyStroke keyStroke)
        {
            keyStrokeToActionIdMap.Remove(keyStroke);
            Debug.WriteLine($"Unregistered binding[{keyStroke}] - {keyStrokeToActionIdMap.Count} bindings");
        }
    }
}
