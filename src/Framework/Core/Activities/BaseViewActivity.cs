using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System;

namespace Aurora.Core.Activities
{
    public abstract class BaseViewActivity<TPresenter, TActivityInfo> 
        : IActivity<TActivityInfo>
        where TPresenter : IPresenter
        where TActivityInfo : ViewActivityInfo
    {
        private IDisposable viewDispose;

        protected BaseViewActivity(TActivityInfo activityInfo)
        {
            this.ActivityInfo = activityInfo;
        }

        [Dependency]
        public IViewFactory ViewFactory { get; set; }
        
        
        protected virtual object[] Parameters => new object[] { ActivityInfo };

        ActivityInfo IActivity.ActivityInfo => this.ActivityInfo;

        public async Task StartAsync()
        {
            var  activeView = await ViewFactory.CreateActiveViewAsync<TPresenter>(this, Parameters);
            this.viewDispose = await AddViewAsync(activeView);
        }

        public TActivityInfo ActivityInfo { get; }

        protected abstract Task<IDisposable> AddViewAsync(ActiveView view);

        public void Dispose()
        {
            viewDispose.Dispose();
        }

    }
}