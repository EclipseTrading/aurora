using System;

namespace Aurora.Core.Activities
{
    public class ActivityInfoAttribute : Attribute
    {
        public ActivityInfoAttribute(Type activityInfoType)
        {
            if (!typeof(ActivityInfo).IsAssignableFrom(activityInfoType))
            {
                throw new ArgumentException("ActivityInfo Type must derive from ActivityInfo");
            }
            this.Type = activityInfoType;
        }
        public Type Type { get; set; }
    }
}