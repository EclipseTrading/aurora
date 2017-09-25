using System;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core
{
    public static class ViewFactoryExtensions
    {
        public static async Task<ActiveView<TPresenter>> CreateActiveViewAsync<TPresenter>(this IViewFactory factory, IActivity activity, params object[] parameters)
            where TPresenter : IPresenter
        {
            var view = await factory.CreateActiveViewAsync(activity, typeof(TPresenter), parameters);
            return new ActiveView<TPresenter>((TPresenter)view.Presenter, view.ViewModel, view.View, view.Activity);
        }

        public static async Task<ActiveView<TPresenter>> CreateActiveViewAsync<TPresenter>(this IViewFactory factory, params object[] parameters)
            where TPresenter : IPresenter
        {
            var view = await factory.CreateActiveViewAsync(null, typeof(TPresenter), parameters);
            return new ActiveView<TPresenter>((TPresenter)view.Presenter, view.ViewModel, view.View, view.Activity);
        }

        public static Task<ActiveView> CreateActiveViewAsync(this IViewFactory factory, Type presenterType, params object[] parameters)
        {
            return factory.CreateActiveViewAsync(null, presenterType, parameters);
        }
    }
}