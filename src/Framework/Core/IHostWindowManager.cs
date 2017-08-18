using System;
using Aurora.Core.Activities;

namespace Aurora.Core
{
    public interface IHostWindowManager
    {
        ITitleBarSettings TitleBarSettings { get; }
        Action CloseAction { get; set; }
    }
}