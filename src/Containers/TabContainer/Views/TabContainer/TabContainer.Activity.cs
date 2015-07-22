using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.TabContainer.Views.TabContainer
{
    [ActivityInfo(typeof(TabContainerActivityInfo))]
    public class TabContainerActivity : ViewContainerActivity<TabContainerPresenter, TabContainerViewModel, TabContainerView, TabContainerActivityInfo>
    {
        private readonly IPresenterFactory presenterFactory;

        public TabContainerActivity(TabContainerActivityInfo activityInfo, IPresenterFactory presenterFactory) : base(activityInfo)
        {
            this.presenterFactory = presenterFactory;
        }

        protected override IViewContainerService CreateViewContainerService()
        {
            return new TabViewContainerService(ContainerRegionManager, presenterFactory);
        }
    }
}
