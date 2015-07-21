using System;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core.Host
{
    public interface IActivityService
    {
        Task StartActivityAsync<TActivityInfo>(TActivityInfo activityInfo) 
            where TActivityInfo : ActivityInfo;

        Task StartActivityAsync(Type activityInfoType, ActivityInfo activityInfo);
    }
}