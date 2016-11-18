using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core.Actions
{
    public interface IAction 
    {
        string Id { get; }

        IActionParameter GetParameter(string key);
        IDictionary<string, IActionParameter> GetParameters();
    }
}