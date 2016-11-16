using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aurora.Core.Actions
{
    public class DefaultEventContext : IEventContext
    {
        private readonly IDictionary<string, object> variables = new Dictionary<string, object>();

        public Window ActiveWindow { get; }
        public IInputElement ActiveElement { get; }
        public IInputElement KeyboardFocusedElement { get; }

        public DefaultEventContext(Window activeWindow = null, IInputElement activeElement = null, IInputElement keyboardFocusedElement = null)
        {
            this.ActiveWindow = activeWindow;
            this.ActiveElement = activeElement;
            this.KeyboardFocusedElement = keyboardFocusedElement;
        }

        public object GetVariable(string name)
        {
            object value;
            return variables.TryGetValue(name, out value)? value : null;
        }

        public IDictionary<string, object> GetAllVariables()
        {
            return new ReadOnlyDictionary<string, object>(variables);
        }

    }
}
