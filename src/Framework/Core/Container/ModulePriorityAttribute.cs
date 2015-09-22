using System;

namespace Aurora.Core.Container
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModulePriorityAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="priority">the priority to assign</param>
        public ModulePriorityAttribute(Priority priority)
        {
            this.Priority = priority;
        }

        /// <summary>
        /// Gets or sets the priority of the module.
        /// </summary>
        /// <value>The priority of the module.</value>
        public Priority Priority { get; private set; }
    }
}
