using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Core
{
    public class DictionaryHelper
    {
        public static TV Get<TK, TV>(IDictionary<TK, TV> map, TK key)
        {
            TV value;
            return map.TryGetValue(key, out value) ? value : default(TV);
        }

        /// <summary>
        /// Safe get from a dictionary
        /// </summary>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="TV"></typeparam>
        /// <param name="map"></param>
        /// <param name="key"></param>
        /// <param name="creatorFunc"></param>
        /// <returns></returns>
        public static TV GetOrCreate<TK, TV>(IDictionary<TK, TV> map, TK key, Func<TV> creatorFunc = null)
        {
            if (creatorFunc == null)
            {
                // Assign default create function
                creatorFunc = () => default(TV);
            }

            TV value;
            if (map.TryGetValue(key, out value))
            {
                // Return value if key found
                return value;
            }

            // Create value if key not found
            value = creatorFunc();
            map.Add(key, value);
            return value;
        }
    }
}
