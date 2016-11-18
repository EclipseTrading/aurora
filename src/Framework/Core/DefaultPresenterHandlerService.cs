using System;
using System.Collections.Generic;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public class DefaultPresenterActionHandlerService : IActionHandlerService
    {
        private readonly IActionHandler parent;
        private readonly IDictionary<IAction, IActionHandler> actionHandlers = new Dictionary<IAction, IActionHandler>();

        public DefaultPresenterActionHandlerService(IActionHandler parent)
        {
            this.parent = parent;
        }

        public bool Execute(ActionEvent evt) {
            if (actionHandlers.Count == 0 || evt.Action == null)
            {
                return (parent?.Execute(evt)).GetValueOrDefault();
            }

            IActionHandler actionHandler;
            return actionHandlers.TryGetValue(evt.Action, out actionHandler) ? actionHandler.Execute(evt) : (parent?.Execute(evt)).GetValueOrDefault();
        }

        public void RegisterHandler(IAction action, IActionHandler actionHandler)
        {
            actionHandlers[action] = actionHandler;
        }

    }
}