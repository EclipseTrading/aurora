using System.Windows;

namespace Aurora.Core.Actions
{
    public interface IEventContext
    {
        Window ActiveWindow { get; }
        IInputElement ActiveElement { get; }
        IInputElement KeyboardFocusedElement { get; }
    }
}