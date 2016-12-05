using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Aurora.Core.Actions
{
    public class DefaultActionService : IActionService
    {
        private readonly Dictionary<string, IAction> idToActionMap = new Dictionary<string, IAction>();

        public void RegisterAction(IAction action)
        {
            if(string.IsNullOrEmpty(action.Id)) 
            {
                throw new ArgumentException("Action missing Id");
            }

            idToActionMap[action.Id] = action;
            Debug.WriteLine($"Registered action[{action.Id}]");
        }

        public IAction GetAction(string actionId)
        {
            IAction action;
            return idToActionMap.TryGetValue(actionId, out action) ? action : null;
        }

        public IDictionary<string, IAction> GetAllActions()
        {
            return new ReadOnlyDictionary<string, IAction>(this.idToActionMap);
        }
    }
}
