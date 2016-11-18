using System.Collections.Generic;
using System.Diagnostics;

namespace Aurora.Core.Actions
{
    public class DefaultActionHandlerService : IActionHandlerService
    {
        private readonly IDictionary<IAction, IActionHandler> handlerMap = new Dictionary<IAction, IActionHandler>();

        public bool Execute(ActionEvent evt)
        {
            lock (handlerMap)
            {
                IActionHandler actionHandler;
                if (handlerMap.TryGetValue(evt.Action, out actionHandler))
                {
                    actionHandler.Execute(evt);
                }
            };
            return true;
        }

        public void RegisterHandler(IAction action, IActionHandler actionHandler)
        {
            lock (handlerMap)
            {
                handlerMap.Add(action, actionHandler);
            }

            Debug.WriteLine($"Registered actionHandler for action[{action.Id}]");
        }
    }
}
