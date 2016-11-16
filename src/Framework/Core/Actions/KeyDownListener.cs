using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Aurora.Core.Actions
{
    public class KeyDownListener
    {
        private readonly Action<KeyEventArgs> dispatcher;

        public KeyDownListener(Application app, Action<KeyEventArgs> dispatcher)
        {
            this.dispatcher = dispatcher;

            app.Activated += OnActivated;
            app.Deactivated += OnDeactivated;
        }

        private void OnActivated(object sender, EventArgs e)
        {
            Console.WriteLine("Activated: Reg Hotkey");
            Application.Current.MainWindow.KeyDown += OnKeyDown;
        }

        private void OnDeactivated(object sender, EventArgs e)
        {
            Console.WriteLine("Deact: Unreg Hotkey");
            Application.Current.MainWindow.KeyDown -= OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            dispatcher.Invoke(e);
        }
    }
}
