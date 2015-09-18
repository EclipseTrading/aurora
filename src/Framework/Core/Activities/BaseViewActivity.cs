using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public abstract class BaseViewActivity<TPresenter, TActivityInfo> 
        : IActivity<TActivityInfo>
        where TPresenter : IPresenter
        where TActivityInfo : ViewActivityInfo
    {

        protected BaseViewActivity(TActivityInfo activityInfo)
        {
            this.ActivityInfo = activityInfo;
        }

        [Dependency]
        public IViewFactory ViewFactory { get; set; }
        
        
        protected virtual object[] Parameters  
        {        
            get { return new object[] { ActivityInfo }; }
        }

        ActivityInfo IActivity.ActivityInfo 
        {
            get { return this.ActivityInfo; }             
        }

        public async Task StartAsync()
        {
            var presenter = await ViewFactory.CreateActiveViewAsync<TPresenter>(this, Parameters);
            await AddViewAsync(presenter);
        }

        public TActivityInfo ActivityInfo { get; private set; }

        protected abstract Task AddViewAsync(ActiveView view);
    }
}