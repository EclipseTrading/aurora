using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Microsoft.Practices.Unity;
using Aurora.Core.Dialog;
using Aurora.Core.ViewContainer;

namespace Aurora.Core
{
    public class ViewFactory : IViewFactory
    {
        private readonly IUnityContainer container;
        private readonly IRelatedTypeResolver<IViewModel> viewModelResolver;
        private readonly IRelatedTypeResolver<FrameworkElement> viewResolver;

        public ViewFactory(IUnityContainer container, IRelatedTypeResolver<IViewModel> viewModelResolver, IRelatedTypeResolver<FrameworkElement> viewResolver)
        {
            this.container = container;
            this.viewModelResolver = viewModelResolver;
            this.viewResolver = viewResolver;
        }
        
        public async Task<ActiveView> CreateActiveViewAsync(IActivity activity, Type presenterType, params object[] parameters)
        {
            var parentHandlerService = (IActionHandlerService)
                parameters.Where(p => (p as TypeOverride)?.Type is IActionHandlerService)
                    .Select(p=> (p as TypeOverride)?.Value)
                    .SingleOrDefault();

            var overrideList =
                parameters.Where(p => !((p as TypeOverride)?.Type is IActionHandlerService))
                .Select(p =>
                {
                    var typeOverride = p as TypeOverride;
                    return (ResolverOverride)(typeOverride != null ?
                        new DependencyOverride(typeOverride.Type, typeOverride.Value) :
                        new DependencyOverride(p.GetType(), p));
                }).ToList();

            var handlerService = new DefaultPresenterActionHandlerService(parentHandlerService ?? container.Resolve<IActionHandlerService>());
            overrideList.Add(new DependencyOverride(typeof(IActionHandlerService), handlerService));

            var overrides = overrideList.ToArray();

            var presenter = (IPresenter)container.Resolve(presenterType, overrides);
            var viewType = viewResolver.ResolveType(presenterType);
            var viewModelType = viewModelResolver.ResolveType(presenterType);
            var view = (FrameworkElement)container.Resolve(viewType, overrides);

            ViewPropertyHelper.SetActionHandlerService(view, handlerService);

            var viewModel = (IViewModel)container.Resolve(viewModelType, overrides);

            ActiveView result = null;
            if (presenter is IViewPresenter)
            {
                var contentContainer = new ContentContainer();
            
                view.DataContext = viewModel;
                var contentContext = new ContentContext();
                contentContext.MainContent = view;
                
                contentContainer.DataContext = contentContext;
                ((IViewPresenter)presenter).ContentContext = contentContext;
                await presenter.InitializeAsync(viewModel);
                result = new ActiveView(presenter, viewModel, contentContainer, activity);
            }
            else
            {
                view.DataContext = viewModel;
                await presenter.InitializeAsync(viewModel);
                result = new ActiveView(presenter, viewModel, view, activity);
            }

            return result;
        }

    }
}
