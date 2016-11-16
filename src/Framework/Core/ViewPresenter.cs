using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Microsoft.Practices.Unity;
using Aurora.Core.Dialog;
using Aurora.Core.ViewContainer;

namespace Aurora.Core
{

    public class ViewPresenter<TViewModel, TActivityInfo> : Presenter<TViewModel, TActivityInfo>, IViewPresenter
        where TViewModel : IViewModel
        where TActivityInfo : ViewActivityInfo
    {
        private readonly List<ActiveView> childViews = new List<ActiveView>();

        public ViewPresenter(TActivityInfo viewActivityInfo, IDependencyHandler dependencyHandler) : base(viewActivityInfo, dependencyHandler)
        {
        }

        [Dependency]
        public IViewFactory ViewFactory { get; set; }

        public ViewActivityInfo ViewActivityInfo => this.ActivityInfo;
        

        public ContentContext ContentContext { get; set; }

        protected virtual async Task<TResult> ShowDialogAsync<TResult>(Type presenterType, params object[] parameters) 
            where TResult : DialogResult
        {
            var dialogView = await this.ViewFactory.CreateActiveViewAsync(null, presenterType, parameters);           
            this.ContentContext.DialogContent = dialogView.View;
            this.ContentContext.IsOpenDialog = true;          
            var result = await ((IDialogViewPresenter<TResult>)dialogView.Presenter).ShowAsync();
            this.ContentContext.IsOpenDialog = false;

            return result;
        }

        protected virtual async Task<ActiveView> AddChildViewAsync<TChildActivityInfo>(Type presenterType, TChildActivityInfo activityInfo, params object[] parameters)
            where TChildActivityInfo : ViewActivityInfo
        {

            var view = await ViewFactory.CreateActiveViewAsync(presenterType, parameters
                .Union(new object[]
                {
                    activityInfo,
                    new TypeOverride<ViewActivityInfo>(activityInfo),
                    new TypeOverride<IDependencyHandler>(DependencyHandler) 
                }).ToArray());
            this.childViews.Add(view);
            return view;
        }

        protected virtual Task<ActiveView> AddChildViewAsync(Type presenterType, params object[] parameters)
        {
            return this.AddChildViewAsync(presenterType, new ViewActivityInfo(null), parameters);
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (var activeView in childViews)
            {
                activeView.Presenter.Dispose();
            }

            childViews.Clear();
        }
    }
}