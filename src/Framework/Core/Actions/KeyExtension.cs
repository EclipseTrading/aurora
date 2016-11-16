using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aurora.Core.Actions
{
    public static class KeyExtension
    {
        public static Key RealKey(this KeyEventArgs evt)
        {
            switch (evt.Key)
            {
                case Key.System:
                    return evt.SystemKey;

                case Key.ImeProcessed:
                    return evt.ImeProcessedKey;

                case Key.DeadCharProcessed:
                    return evt.DeadCharProcessedKey;

                default:
                    return evt.Key;
            }
        }
    }
}
