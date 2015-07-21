using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Host
{
    public class DefaultActivityService : IActivityService
    {
        private readonly Dictionary<Type, Type> activityInfoToActivityCache = new Dictionary<Type, Type>();
        private readonly IUnityContainer container;

        public DefaultActivityService(IUnityContainer container)
        {
            this.container = container;
        }

        public Task StartActivityAsync<TActivityInfo>(TActivityInfo activityInfo) where TActivityInfo : ActivityInfo
        {
            return this.StartActivityAsync(typeof (TActivityInfo), activityInfo);
        }

        public async Task StartActivityAsync(Type activityInfoType, ActivityInfo activityInfo)
        {
            var activityType = GetActivityType(activityInfoType);
            var activityInfoOverride = new DependencyOverride(activityInfoType, new InjectionParameter(activityInfo));
            var activity = (IActivity)container.Resolve(activityType, activityInfoOverride);
            await activity.StartAsync();
        }

        private Type GetActivityType(Type infoType)
        {

            if (activityInfoToActivityCache.ContainsKey(infoType))
                return activityInfoToActivityCache[infoType];

            var activityType = (from a in AppDomain.CurrentDomain.GetAssemblies()
                from aType in a.GetTypes()
                where typeof(IActivity).IsAssignableFrom(aType)
                where IsMatchingActivity(infoType, aType)
                select aType).FirstOrDefault();

            activityInfoToActivityCache[infoType] = activityType;

            return activityInfoToActivityCache[infoType];
        }

        private static bool IsMatchingActivity(Type infoType, Type activityType)
        {
            if (!activityType.IsDefined(typeof(ActivityInfoAttribute), true))
            {
                return false;
            }

            var attribute = (ActivityInfoAttribute)activityType.GetCustomAttribute(typeof(ActivityInfoAttribute), true);
            return infoType == attribute.Type;
        }
    }
}
