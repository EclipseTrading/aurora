using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public abstract class BaseViewActivity<TPresenter, TViewModel, TView, TActivityInfo> 
        : IActivity<TActivityInfo>
        where TView : FrameworkElement
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel, TView>
        where TActivityInfo : ViewActivityInfo
    {

        protected BaseViewActivity(TActivityInfo activityInfo)
        {
            ActivityInfo = activityInfo;
        }

        [Dependency]
        public IPresenterFactory PresenterFactory { get; set; }
        
        
        protected virtual object[] Parameters => new object[] { ActivityInfo };

        public async Task StartAsync()
        {
            var presenter = await PresenterFactory.CreatePresenterAsync<TPresenter, TViewModel, TView>(Parameters);
            await AddPresenterAsync(presenter);
        }

        public TActivityInfo ActivityInfo { get;  }

        protected abstract Task AddPresenterAsync(TPresenter presenter);
    }
}