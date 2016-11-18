using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core.Actions
{
    public class DefaultAction : IAction
    {
        private readonly IDictionary<string, IActionParameter> parameters;
        public string Id { get; private set; }

        public DefaultAction(string id, IEnumerable<IActionParameter> parameters = null)
        {
            this.Id = id;
            this.parameters = parameters?.ToDictionary(param => param.Key) ?? new Dictionary<string, IActionParameter>();
        }

        public IActionParameter GetParameter(string key)
        {
            IActionParameter param;
            return parameters.TryGetValue(key, out param)? param : null;
        }

        /// <summary>
        /// Return a read-only parameter map
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, IActionParameter> GetParameters()
        {
            return new ReadOnlyDictionary<string, IActionParameter>(parameters);
        }


    }
}