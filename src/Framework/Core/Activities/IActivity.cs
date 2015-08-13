using System.Threading.Tasks;

namespace Aurora.Core.Activities
{
    public interface IActivity<out TActivityInfo> : IActivity
        where TActivityInfo : ActivityInfo
    {

        new TActivityInfo ActivityInfo { get;  }
    }

    public interface IActivity
    {
        ActivityInfo ActivityInfo { get; }
        Task StartAsync();
    }
}