using Aurora.Core;

namespace Aurora.TabContainer.Views.TabContainer
{
    public class TabContainerPresenter : Presenter<TabContainerViewModel, TabContainerActivityInfo>
    {
        public TabContainerPresenter(TabContainerActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}