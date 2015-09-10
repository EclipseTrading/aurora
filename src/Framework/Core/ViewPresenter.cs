using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Microsoft.Practices.Unity;

namespace Aurora.Core
{
    public class ViewPresenter<TViewModel, TActivityInfo> : Presenter<TViewModel, TActivityInfo>, IViewPresenter
        where TViewModel : IViewModel
        where TActivityInfo : ViewActivityInfo
    {
        private readonly List<ActiveView> childViews = new List<ActiveView>();

        public ViewPresenter(TActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }

        [Dependency]
        public IViewFactory ViewFactory { get; set; }

        public ViewActivityInfo ViewActivityInfo => ActivityInfo;

        protected virtual async Task<ActiveView> AddChildView(Type presenterType, params object[] parameters)
        {
            var view = await ViewFactory.CreateActiveViewAsync(presenterType, parameters);
            this.childViews.Add(view);
            return view;
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (var activeView in childViews)
            {
                activeView.Presenter.Dispose();
            }
        }
    }
}