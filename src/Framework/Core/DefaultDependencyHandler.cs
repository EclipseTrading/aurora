using System;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public class DefaultDependencyHandler : IDependencyHandler
    {
        public IDependencyHandler Parent { get; private set; }
        public Func<ActionEvent, bool> Delegate { private get; set; }

        public DefaultDependencyHandler(IDependencyHandler parent)
        {
            this.Parent = parent;
        }

        public bool Execute(ActionEvent evt) {
            if (this.Delegate == null) return Parent.Execute(evt);

            return this.Delegate.Invoke(evt) || Parent.Execute(evt);
        }

        public void Register(IAction action, IHandler handler)
        {
            
        }

    }
}