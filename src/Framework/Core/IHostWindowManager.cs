using System;
using Aurora.Core.Activities;

namespace Aurora.Core
{
    public interface IHostWindowManager
    {
        TitleBarSettings TitleBarSettings { get; }
        Action CloseAction { get; set; }
    }
}