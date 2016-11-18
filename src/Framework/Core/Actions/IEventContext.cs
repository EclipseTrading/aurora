using System;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.Core.Actions
{
    public interface IEventContext
    {
        Window ActiveWindow { get; }
        IInputElement ActiveElement { get; }
        IInputElement KeyboardFocusedElement { get; }
    }
}