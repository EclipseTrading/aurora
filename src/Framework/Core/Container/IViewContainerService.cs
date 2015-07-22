using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.Core.Container
{
    public interface IViewContainerService
    {
        Task AddViewAsync<TPresenter, TViewModel, TView, TActivityInfo>(TPresenter view, TActivityInfo activityInfo)
            where TPresenter : IPresenter<TViewModel, TView>
            where TViewModel : IViewModel
            where TView : FrameworkElement
            where TActivityInfo : ViewActivityInfo;
    }
}
