using Aurora.Core;
using Aurora.Core.ViewContainer;
using Aurora.Core.Workspace;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class PresenterLayoutDocument : LayoutDocument, IViewContainerService
    {
        public ActiveView View { get; set; }
        public ViewContext ViewContext { get; }

        public PresenterLayoutDocument(ViewContext viewContext)
       {
            this.ViewContext = viewContext;
            this.View = this.ViewContext.View;
            this.Content = this.View.View;
            var viewActivityInfo = this.ViewContext.Info;
            this.Title = viewActivityInfo?.Title;
            this.CanClose = viewActivityInfo?.IsCloseable ?? true;
            this.WorkspaceLocation = viewActivityInfo?.WorkspaceLocation;

            var viewContainerAware = this.View.Presenter as IViewContainerAware;
            if (viewContainerAware != null)
            {
                viewContainerAware.ViewContainerService = this;
            }
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public WorkspaceLocation WorkspaceLocation { get; }
    }
}