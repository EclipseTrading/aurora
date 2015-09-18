using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Interop;

namespace Aurora.Hosting
{
    public class WindowResizeBehavior : Behavior<UIElement>
    {
        private static readonly Dictionary<ResizeDirection, Cursor> CursorMap = new Dictionary<ResizeDirection, Cursor>
        {
            { ResizeDirection.Left, Cursors.SizeWE },
            { ResizeDirection.Right, Cursors.SizeWE },
            { ResizeDirection.Top, Cursors.SizeNS },
            { ResizeDirection.Bottom, Cursors.SizeNS },
            { ResizeDirection.TopLeft, Cursors.SizeNWSE },
            { ResizeDirection.TopRight, Cursors.SizeNESW },
            { ResizeDirection.BottomLeft, Cursors.SizeNESW },
            { ResizeDirection.BottomRight, Cursors.SizeNWSE }
        };

        private const int WmSyscommand = 0x112;
        private HwndSource hwndSource;

        public ResizeDirection Direction { get; set; }

        public Window Window
        {
            get { return Window.GetWindow(AssociatedObject); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.PreviewMouseDown += AssociatedObject_PreviewMouseDown;
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
        }


        private void AssociatedObject_MouseEnter(object sender, MouseEventArgs e)
        {
            var cursor = CursorMap[this.Direction];
            Window.Cursor = cursor;
        }
        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                Window.Cursor = Cursors.Arrow;
            }
        }

        private void AssociatedObject_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var cursor = CursorMap[this.Direction];
            Window.Cursor = cursor;
            SendMessage(HwndSource.Handle, WmSyscommand, (IntPtr)(61440 + Direction), IntPtr.Zero);
        }

        public HwndSource HwndSource
        {
            get
            {
                if (hwndSource != null)
                    return hwndSource;

                var win = Window.GetWindow(AssociatedObject);
                if (win != null)
                {
                    hwndSource = PresentationSource.FromVisual(win) as HwndSource;
                }

                return hwndSource;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    }
}
