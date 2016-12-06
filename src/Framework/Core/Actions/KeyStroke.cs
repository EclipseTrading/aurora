using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aurora.Core.Actions
{
    public class KeyStroke
    {
        public Key Key { get; }
        public bool IsCtrlDown { get; }
        public bool IsAltDown { get; }
        public bool IsShiftDown { get; }
        public KeyEventArgs Evt { get; }

        public KeyStroke(Key key, bool ctrl = false, bool alt = false, bool shift = false, KeyEventArgs evt = null)
        {
            Key = key;
            IsCtrlDown = ctrl;
            IsAltDown = alt;
            IsShiftDown = shift;
            Evt = evt;
        }

        public KeyStroke(KeyEventArgs evt) : this(
            evt.RealKey(),
            Keyboard.Modifiers.HasFlag(ModifierKeys.Control),
            Keyboard.Modifiers.HasFlag(ModifierKeys.Alt),
            Keyboard.Modifiers.HasFlag(ModifierKeys.Shift),
            evt)
        {
        }

        protected bool Equals(KeyStroke other)
        {
            return Equals(Key, other.Key) && IsCtrlDown == other.IsCtrlDown && IsAltDown == other.IsAltDown && IsShiftDown == other.IsShiftDown;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((KeyStroke) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Key.GetHashCode();
                hashCode = (hashCode*397) ^ IsCtrlDown.GetHashCode();
                hashCode = (hashCode*397) ^ IsAltDown.GetHashCode();
                hashCode = (hashCode*397) ^ IsShiftDown.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (IsCtrlDown)
            {
                sb.Append("Ctrl-");
            }
            if (IsAltDown)
            {
                sb.Append("Alt-");
            }
            if (IsShiftDown)
            {
                sb.Append("Shift-");
            }
            return sb.Append(Key).ToString();
        }
    }
}
