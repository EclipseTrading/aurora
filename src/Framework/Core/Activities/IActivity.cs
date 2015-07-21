using System.Threading.Tasks;

namespace Aurora.Core.Activities
{
    public interface IActivity<out TActivityInfo> : IActivity
        where TActivityInfo : ActivityInfo
    {

        TActivityInfo ActivityInfo { get;  }
    }

    public interface IActivity
    {
        Task StartAsync();
    }
}