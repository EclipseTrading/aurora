using System.Threading.Tasks;
using Aurora.Core.Container;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public class ContainerActivity<TPresenter, TActivityInfo>
        : IActivity<TActivityInfo>
        where TPresenter : IPresenter
        where TActivityInfo : ContainerActivityInfo
    {
        private IRegionManager containerRegionManager;

        protected ContainerActivity(TActivityInfo activityInfo)
        {
            ActivityInfo = activityInfo;
        }

        [Dependency]
        public IContainerService ContainerService { get; set; }

        [Dependency]
        public IViewManager ViewManager { get; set; }

        [Dependency]
        public IViewFactory ViewFactory { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public IRegionManager ContainerRegionManager => containerRegionManager ?? (containerRegionManager = RegionManager.CreateRegionManager());

        public TActivityInfo ActivityInfo { get; }

        ActivityInfo IActivity.ActivityInfo => this.ActivityInfo;

        public virtual async Task StartAsync()
        {
            var activeView = await ViewFactory.CreateActiveViewAsync<TPresenter>(ActivityInfo,
                new TypeOverride<IRegionManager>(ContainerRegionManager));
            ContainerService.SetViewContainer(ActivityInfo.Location, activeView.View);
        }

        public void Dispose()
        {

        }
    }
}