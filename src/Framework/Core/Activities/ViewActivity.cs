using System.Threading.Tasks;
using Aurora.Core.Container;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public class ViewActivity<TPresenter> : ViewActivity<TPresenter, ViewActivityInfo>
        where TPresenter : IPresenter
    {
        public ViewActivity(ViewActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }

    public class ViewActivity<TPresenter, TActivityInfo> : BaseViewActivity<TPresenter, TActivityInfo>
        where TPresenter : IPresenter
        where TActivityInfo : ViewActivityInfo

    {
        public ViewActivity(TActivityInfo activityInfo) : base(activityInfo)
        {
        }

        [Dependency]
        public IViewManager ViewManager { get; set; }

        protected async override Task AddViewAsync(ActiveView view)
        {
            await ViewManager.AddViewAsync(view, ActivityInfo);
        }
    }
}