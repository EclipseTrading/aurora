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

        public IRegionManager ContainerRegionManager 
        {
            get { return containerRegionManager ?? (containerRegionManager = RegionManager.CreateRegionManager()); }
        }

        public TActivityInfo ActivityInfo { get; private set; }

        ActivityInfo IActivity.ActivityInfo
        {
            get { return this.ActivityInfo; }
        }

        public virtual async Task StartAsync()
        {
            var presenter = await ViewFactory.CreateActiveViewAsync<TPresenter>(ActivityInfo,
                new TypeOverride<IRegionManager>(ContainerRegionManager));
            ContainerService.SetViewContainer(ActivityInfo.Location, presenter.View);
        }
    }
}