using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core.Container
{
    public interface IViewContainerService
    {
        Task AddViewAsync<TActivityInfo>(ActiveView view, TActivityInfo activityInfo)
            where TActivityInfo : ViewActivityInfo;
    }
}
