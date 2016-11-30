using System;
using System.Windows.Controls;
using Aurora.Core.ViewContainer;
using Aurora.Core.Workspace;
using Syncfusion.Windows.Tools.Controls;


namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    public class PresenterLayoutDocument : ContentControl, IViewContainerService
    {
        public ViewContext ViewContext { get; }

        public ViewLocation ViewLocation { get; }

        public PresenterLayoutDocument(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
            this.Content = this.ViewContext.View.View;

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
            this.ViewContext.Info.Title = title;
            DockingManager.SetHeader(this, title);
        }

        public void CloseView()
        {
            DockingManager.GetDockingManager(this).Children.Remove(this);
        }

    }
}
