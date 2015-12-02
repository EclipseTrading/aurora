using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Aurora.Core.Dialog
{

    public class DialogControl : ContentControl
    {

        public static readonly DependencyProperty IsOpenProperty
            = DependencyProperty.Register("IsOpen",
                                          typeof(bool),
                                          typeof(DialogControl),
                                          new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsOpenedChanged));

        static DialogControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DialogControl), new FrameworkPropertyMetadata(typeof(DialogControl)));
        }

        public bool IsOpen
        {
            get { return (bool)this.GetValue(IsOpenProperty); }
            set { this.SetValue(IsOpenProperty, value); }
        }

        private static void IsOpenedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (Equals(e.OldValue, e.NewValue))
            {
                return;
            }

            var dialog = (DialogControl)dependencyObject;

            Action openedChangedAction = () =>
            {

                VisualStateManager.GoToState(dialog, (bool)e.NewValue == false ? "Hide" : "Show", true);

            };

            dialog.Dispatcher.BeginInvoke(DispatcherPriority.Background, openedChangedAction);

        }

    }
}