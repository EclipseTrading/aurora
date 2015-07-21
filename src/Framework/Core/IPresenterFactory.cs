using System.Threading.Tasks;
using System.Windows;

namespace Aurora.Core
{
    public interface IPresenterFactory
    {
        Task<TPresenter> CreatePresenterAsync<TPresenter, TViewModel, TView>(params object[] parameters)
            where TViewModel : IViewModel
            where TView : FrameworkElement
            where TPresenter : IPresenter<TViewModel, TView>;
    }
}