using Aurora.Core;
using Aurora.Core.Actions;

namespace Aurora.TabContainer.Views.TabContainer
{
    public class TabContainerPresenter : Presenter<TabContainerViewModel, TabContainerActivityInfo>
    {
        public TabContainerPresenter(TabContainerActivityInfo activityInfo, IActionHandlerService actionHandlerService) : base(activityInfo, actionHandlerService)
        {
        }
    }
}