using Aurora.Core.Activities;

namespace Aurora.Core
{
    public class ViewPresenter<TViewModel, TActivityInfo> : Presenter<TViewModel, TActivityInfo>, IViewPresenter
        where TViewModel : IViewModel
        where TActivityInfo : ViewActivityInfo
    {
        public ViewPresenter(TActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }

        public ViewActivityInfo ViewActivityInfo => ActivityInfo;
    }
}