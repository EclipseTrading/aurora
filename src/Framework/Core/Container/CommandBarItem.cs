using System;

namespace Aurora.Core.Container
{
    public abstract class CommandBarItem
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public abstract MenuType MenuType { get; }
    }
}