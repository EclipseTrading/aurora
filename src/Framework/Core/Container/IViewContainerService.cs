using System.Threading.Tasks;
using Aurora.Core.Activities;
using System;

namespace Aurora.Core.Container
{
    public interface IViewContainerService
    {
        Task<IDisposable> AddViewAsync<TActivityInfo>(ActiveView view, TActivityInfo activityInfo)
            where TActivityInfo : ViewActivityInfo;
    }
}
