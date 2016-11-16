using Aurora.Core;

namespace Aurora.TabContainer.Views.TabContainer
{
    public class TabContainerPresenter : Presenter<TabContainerViewModel, TabContainerActivityInfo>
    {
        public TabContainerPresenter(TabContainerActivityInfo activityInfo, IDependencyHandler dependencyHandler) : base(activityInfo, dependencyHandler)
        {
        }
    }
}