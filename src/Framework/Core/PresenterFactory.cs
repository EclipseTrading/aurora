using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;

namespace Aurora.Core
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly IUnityContainer container;

        public PresenterFactory(IUnityContainer container)
        {
            this.container = container;
        }
        
        public async Task<TPresenter> CreatePresenterAsync<TPresenter, TViewModel, TView>(params object[] parameters)
            where TViewModel : IViewModel
            where TView : FrameworkElement
            where TPresenter : IPresenter<TViewModel, TView>
        {
            var overrides =
                parameters.Select(p =>
                {
                    var typeOverride = p as TypeOverride;
                    return (ResolverOverride)(typeOverride != null ?
                        new DependencyOverride(typeOverride.Type, typeOverride.Value) :
                        new DependencyOverride(p.GetType(), p));
                }).ToArray();

            var presenter = container.Resolve<TPresenter>(overrides);
            var view = container.Resolve<TView>(overrides);
            var viewModel = container.Resolve<TViewModel>(overrides);

            await presenter.InitializeAsync(viewModel, view);
            
            return presenter;
        }
    }
}
