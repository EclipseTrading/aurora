using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.ViewContainer;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class PresenterLayoutDocument : LayoutDocument, IViewContainerService
    {
        public ActiveView View { get; }

        public PresenterLayoutDocument(ActiveView view)
        {
            View = view;
            this.Content = view.View;
            var viewActivityInfo = view.Activity.ActivityInfo as ViewActivityInfo;
            this.Title = viewActivityInfo?.Title;
            this.CanClose = viewActivityInfo?.IsCloseable ?? true;

            var viewContainerAware = view.Presenter as IViewContainerAware;
            if (viewContainerAware != null)
            {
                viewContainerAware.ViewContainerService = this;
            }
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }
    }
}