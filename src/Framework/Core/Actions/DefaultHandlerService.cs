using System.Collections.Generic;
using System.Diagnostics;

namespace Aurora.Core.Actions
{
    public class DefaultHandlerService : IHandlerService
    {
        private readonly IDictionary<IAction, IHandler> handlerMap = new Dictionary<IAction, IHandler>();

        public void Execute(ActionEvent evt)
        {
            lock (handlerMap)
            {
                IHandler handler;
                if (handlerMap.TryGetValue(evt.Action, out handler))
                {
                    handler.Execute(evt);
                }
            };
        }

        public void RegisterHandler(IAction action, IHandler handler)
        {
            lock (handlerMap)
            {
                handlerMap.Add(action, handler);
            }

            Debug.WriteLine($"Registered handler for action[{action.Id}]");
        }
    }
}
