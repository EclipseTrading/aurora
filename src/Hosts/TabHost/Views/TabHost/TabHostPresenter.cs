using Aurora.Core;

namespace Aurora.TabHost.Views.TabHost
{
    public class TabHostPresenter : Presenter<TabHostViewModel, TabHostView, TabHostActivityInfo>
    {
        public TabHostPresenter(TabHostActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}