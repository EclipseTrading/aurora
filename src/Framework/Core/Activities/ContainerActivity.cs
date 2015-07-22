using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Container;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Aurora.Core.Activities
{
    public class ContainerActivity<TPresenter, TViewModel, TView, TActivityInfo>
        : IActivity<TActivityInfo>
        where TView : FrameworkElement
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel, TView>
        where TActivityInfo : ContainerActivityInfo
    {
        private IRegionManager containerRegionManager;
        public TActivityInfo ActivityInfo { get; set; }

        protected ContainerActivity(TActivityInfo activityInfo)
        {
            ActivityInfo = activityInfo;
        }

        [Dependency]
        public IContainerService ContainerService { get; set; }

        [Dependency]
        public IViewManager ViewManager { get; set; }

        [Dependency]
        public IPresenterFactory PresenterFactory { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public IRegionManager ContainerRegionManager =>
            containerRegionManager ?? (containerRegionManager = RegionManager.CreateRegionManager());

        public virtual async Task StartAsync()
        {
            var presenter = await PresenterFactory.CreatePresenterAsync<TPresenter, TViewModel, TView>(ActivityInfo,
                new TypeOverride<IRegionManager>(ContainerRegionManager));
            ContainerService.SetViewContainer(ActivityInfo.Location, presenter.View);
        }
    }
}