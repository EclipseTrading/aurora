using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;

namespace Aurora.TabContainer.Views.TabContainer
{
    [ActivityInfo(typeof(TabContainerActivityInfo))]
    public class TabContainerActivity : ViewContainerActivity<TabContainerPresenter, TabContainerActivityInfo>
    {
        private readonly IViewFactory viewFactory;

        public TabContainerActivity(TabContainerActivityInfo activityInfo, IViewFactory viewFactory) : base(activityInfo)
        {
            this.viewFactory = viewFactory;
        }

        protected override IViewContainerService CreateViewContainerService()
        {
            return new TabViewContainerService(ContainerRegionManager, viewFactory);
        }
    }
}
