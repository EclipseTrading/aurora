using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core.Actions
{
    public interface IActionService
    {
        void RegisterAction(IAction action);

        IAction GetAction(string actionId);

        IDictionary<string, IAction> GetAllActions();
    }
}