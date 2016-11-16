using System;
using System.Collections.Generic;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public class DefaultDependencyHandler : IDependencyHandler
    {
        public IDependencyHandler Parent { get; private set; }
        private readonly IDictionary<IAction, IHandler> actionHandlers = new Dictionary<IAction, IHandler>();

        public DefaultDependencyHandler(IDependencyHandler parent)
        {
            this.Parent = parent;
        }

        public bool Execute(ActionEvent evt) {
            if (actionHandlers.Count == 0 || evt.Action == null)
            {
                return false;
            }

            IHandler handler;
            return actionHandlers.TryGetValue(evt.Action, out handler) && handler.Execute(evt);
        }

        public void RegisterActionHandler(IAction action, IHandler handler)
        {
            actionHandlers[action] = handler;
        }

    }
}