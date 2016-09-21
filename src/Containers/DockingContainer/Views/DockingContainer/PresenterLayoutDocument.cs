using Aurora.Core;
using Aurora.Core.ViewContainer;
using Aurora.Core.Workspace;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class PresenterLayoutDocument : LayoutDocument, IViewContainerService
    {
        public ViewContext ViewContext { get; }

        public PresenterLayoutDocument(ViewContext viewContext)
       {
            this.ViewContext = viewContext;
            this.Content = this.ViewContext.View.View;
            this.Title = this.ViewContext.Info?.Title;
            this.CanClose = this.ViewContext.Info?.IsCloseable ?? true;
            this.ViewLocation = this.ViewContext.Info?.ViewLocation;

            var viewContainerAware = this.ViewContext.View.Presenter as IViewContainerAware;
            if (viewContainerAware != null)
            {
                //attach PresenterLayoutDocument to Presenter
                viewContainerAware.ViewContainerService = this;
            }
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void CloseView()
        {
            this.Close();
        }

        public ViewLocation ViewLocation { get; }

    }
}