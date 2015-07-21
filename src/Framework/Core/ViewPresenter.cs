using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.Core
{
    public class ViewPresenter<TViewModel, TView, TActivityInfo> : Presenter<TViewModel, TView, TActivityInfo>   , IViewPresenter
        where TViewModel : IViewModel
        where TView : FrameworkElement
        where TActivityInfo : ViewActivityInfo
    {
        public ViewPresenter(TActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }

        public ViewActivityInfo ViewActivityInfo => ActivityInfo;
    }
}