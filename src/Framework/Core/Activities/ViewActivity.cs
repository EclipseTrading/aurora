using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Host;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public class ViewActivity<TPresenter, TViewModel, TView> : ViewActivity<TPresenter, TViewModel, TView, ViewActivityInfo>
        where TPresenter : IPresenter<TViewModel, TView>
        where TViewModel : IViewModel
        where TView : FrameworkElement
    {
        public ViewActivity(ViewActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }

    public class ViewActivity<TPresenter, TViewModel, TView, TActivityInfo> : BaseViewActivity<TPresenter, TViewModel, TView, TActivityInfo>
        where TView : FrameworkElement
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel, TView>
        where TActivityInfo : ViewActivityInfo

    {
        public ViewActivity(TActivityInfo activityInfo) : base(activityInfo)
        {
        }

        [Dependency]
        public IViewManager ViewManager { get; set; }

        protected async override Task AddPresenterAsync(TPresenter presenter)
        {
            await ViewManager.AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(presenter, ActivityInfo);
        }
    }
}