using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Core.Actions
{
    public interface IBindingService
    {
        void RegisterBinding(KeyStroke keyStroke, IAction action);
        void UnregisterBinding(KeyStroke keyStroke);
    }
}
